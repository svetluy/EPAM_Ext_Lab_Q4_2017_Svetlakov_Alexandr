using AutoMapper;
using KnowledgeTestingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KnowledgeTestingApplication.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = DataAcess.TestManagment.GetUser(model.Email);
                if ( user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    foreach (var role in user.Role)
                    {
                        if (role == DataAcess.DomainModels.Role.Admin)      
                        {
                            //Roles.
                        }
                    }
                    return RedirectToAction("Index", "Test");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterModel, DataAcess.DomainModels.User>());
                var mapper = config.CreateMapper();
                

                if (DataAcess.TestManagment.GetUser(model.Email) == null)
                {
                    var user = mapper.Map<DataAcess.DomainModels.User>(model);
                    DataAcess.TestManagment.CreateUser(user);
                    if (DataAcess.TestManagment.GetUser(model.Email) != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Test");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}