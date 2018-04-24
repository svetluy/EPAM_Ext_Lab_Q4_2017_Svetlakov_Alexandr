using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingApplication.Models;

namespace KnowledgeTestingApplication.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAcess.DomainModels.User, User>());
            var mapper = config.CreateMapper();
            
            UserIndexViewModel usersViewModel = new UserIndexViewModel();
            var userlist = DataAcess.TestManagment.GetUsersList();
            foreach (var userlogin in userlist)
            {
                var user = mapper.Map<User>(DataAcess.TestManagment.GetUser(userlogin));
                usersViewModel.Users.Add(user);
            }
            return View(usersViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int id, string login)
        {
            var editUserViewModel = new EditUserModel();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAcess.DomainModels.Role, Role>());
            var mapper = config.CreateMapper();
            editUserViewModel.Id = id;
            editUserViewModel.Email = login;
            editUserViewModel.Role = mapper.Map<List<DataAcess.DomainModels.Role>, List<Role>>(DataAcess.TestManagment.GetUserRoles(id));
            return View(editUserViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(EditUserModel model)
        {
            return RedirectToAction("Index");
        }

        
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id, string login)
        {
            var user = DataAcess.TestManagment.GetUser(login);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAcess.DomainModels.User, User>());
            var mapper = config.CreateMapper();

            return View(mapper.Map<User>(user)); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            DataAcess.TestManagment.DeleteUser(id);
            return View();
        }
    }
}