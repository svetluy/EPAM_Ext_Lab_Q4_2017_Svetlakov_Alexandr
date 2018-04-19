using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingApplication.Models
{
    public class TestResultViewModel
    {

        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public int TotalQuestions { get; set; }
        public int UserAnswered { get; set; }
        public int UserRightAnswered { get; set; }
        public double UserScore
        {
            get
            {
                var score = (UserRightAnswered / (double)TotalQuestions) * 100;
                return score;
            }
        }

        public List<QuestionResultViewModel> QuestionInfo { get; set; } = new List<QuestionResultViewModel>();
    }

    public class QuestionResultViewModel
    {
        public int QuestionId { get; set; }
        public List<string> UserAnswer { get; set; } = new List<string>();
        public List<string> RightAnswer { get; set; } = new List<string>();
    }
}