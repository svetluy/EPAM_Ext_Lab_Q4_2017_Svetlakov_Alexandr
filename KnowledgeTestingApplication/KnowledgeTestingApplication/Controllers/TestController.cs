using AutoMapper;
using KnowledgeTestingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeTestingApplication.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            ViewBag.User = User.Identity.Name;
            int pageSize = 3; // количество объектов на страницу
            var testsPerPages = DataAcess.TestManagment.GetTestsForPage(page, pageSize);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAcess.DomainModels.Test, IndexTestViewModel>());
            var mapper = config.CreateMapper();
            var tests = mapper.Map<List<DataAcess.DomainModels.Test>, IEnumerable<IndexTestViewModel>>(testsPerPages);
            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = DataAcess.TestManagment.GetTestsCount() };
            var ivm = new IndexViewModel { PageInfo = pageInfo, Tests = tests };
            return View(ivm);
        }

        public ActionResult PreStartTest(int testId)
        {
            DataAcess.TestManagment.ClearUserChoice(testId);
            return RedirectToAction("StartTest", new {testId});
        }

        [Authorize]
        public ActionResult StartTest(int testId, int questionId = 1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAcess.DomainModels.Question, QuestionViewModel>());
            var mapper = config.CreateMapper();
            var question = mapper.Map<DataAcess.DomainModels.Question, QuestionViewModel>(DataAcess.TestManagment.GetQuestion(testId, questionId));
            var pageInfo = new QuestionPageInfo { TestId = testId, QuestionId = questionId, TotalPages = DataAcess.TestManagment.GetQuestionList(testId).Count};
            var stqvm = new StartTestQuestionViewModel { QuestionPageInfo = pageInfo, Question = question };
            return View(stqvm);
        }

        [HttpPost]
        public ActionResult CheckAnswer(int testId, int questionId)
        {
            var separator = new char[] { ',' };
            var userchoice = Request.Params[questionId.ToString()];
            if (userchoice != null)
            {
                DataAcess.TestManagment.SetUserChoice(testId, questionId, userchoice.Split(separator));
            }
            questionId++;
            if (questionId <= DataAcess.TestManagment.GetQuestionList(testId).Count)
            {
                return RedirectToAction("StartTest", new { testId, questionId });
            }
            else
            {
                return RedirectToAction("TestResult", new { testId });
            }
        }

        [Authorize]
        public ActionResult TestResult(int testId)
        {
            var questions = DataAcess.TestManagment.GetQuestionList(testId);
            TestResultViewModel testResult = new TestResultViewModel
            {
                TestId = testId,
                TestName = DataAcess.TestManagment.GetTest(testId).TestName,
                TotalQuestions = questions.Count
            };


            foreach (var questionid in questions)
            {
                var questionResult = new QuestionResultViewModel { QuestionId = questionid };
                var question = DataAcess.TestManagment.GetQuestion(testId, questionid);
                int userRightAnswered = 0;
                foreach (var option in question.UserChoice)
                {
                    if (!questionResult.UserAnswer.Contains(option))
                    {
                        questionResult.UserAnswer.Add(option);
                    }

                    foreach (var answer in question.RightAnswer)
                    {
                        if (!questionResult.RightAnswer.Contains(answer))
                        {
                            questionResult.RightAnswer.Add(answer);
                        }

                        if (option.ToLower().Contains(answer.ToLower()))
                        {
                            userRightAnswered++;
                        }
                    }
                }

                if (userRightAnswered == question.RightAnswer.Count)
                {
                    testResult.UserRightAnswered++;
                }
                if (question.UserChoice.Count > 0)
                {
                    testResult.UserAnswered++;
                }
                if (DataAcess.TestManagment.GetUser(User.Identity.Name).Role.Contains(DataAcess.DomainModels.Role.Admin))
                {
                    testResult.QuestionInfo.Add(questionResult);
                }

            }
            return View(testResult);
        }

    }
}