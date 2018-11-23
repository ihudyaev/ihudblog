using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IH.IhudBlog.Web.Models;
using IH.IhudBlog.Core.Models;

namespace IH.IhudBlog.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        Core.NHibernate.NHUserRepository UserRepository;

        public UserController()
        {
            UserRepository = new IH.IhudBlog.Core.NHibernate.NHUserRepository();
        }
        // GET: User
        public ActionResult Index(string sortOrder = "Login")
        {
            ViewBag.LoginSortParm = String.IsNullOrEmpty(sortOrder) ? "Login_desc" : "";
            ViewBag.BirthDateSortParm = sortOrder == "BirthDay" ? "BirthDay_desc" : "BirthDay";
            ViewBag.EmailSortParam = sortOrder == "Email" ? "Email_desc" : "Email";


            IEnumerable<User> all = UserRepository.GetAllValid();


            //соритровка
            switch (sortOrder)
            {
                case "Login_desc":
                    all = all.OrderByDescending(s => s.Login);
                    break;
                case "BirthDay_desc":
                    all = all.OrderByDescending(s => s.Birthday);
                    break;
                case "Birthday":
                    all = all.OrderBy(s => s.Birthday);
                    break;
                case "Email_desc":
                    all = all.OrderByDescending(s => s.Email);
                    break;
                case "Email":
                    all = all.OrderBy(s => s.Email);
                    break;
                default:
                    all = all.OrderBy(s => s.Login);
                    break;
            }


            List<UserViewModel> model = new List<UserViewModel>();
            foreach (User user in all)
            {
                model.Add(new UserViewModel(user));
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult NewUser()
        {
            
                UserViewModel userT = new UserViewModel();
                return View(userT);

        }

        [HttpGet]
        public ActionResult EditUser(long userid)
        {
            if (userid == -1)
            {
                UserViewModel userT = new UserViewModel();
                return View(userT);
            }


            User user = UserRepository.LoadById(userid);
            UserViewModel model = new UserViewModel(user);
            user.Id = UserRepository.Create().Id;

            var result = View(model);

            return result;


        }


        // GET: Note
        [HttpPost]
        public ActionResult EditUser(UserViewModel model)//, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Проверьте, что заполнены все поля! 😊");
                return View();
            }


            if (model.Id == -1)
            {
                model.Id = UserRepository.Create().Id;
            }
            User SaveUser = UserViewModel.Conversion(model);

            UserRepository.Save(SaveUser);

            IEnumerable<User> all = UserRepository.GetAllValid();

            List<UserViewModel> modelList = new List<UserViewModel>();


            foreach (User user in all)
            {
                modelList.Add(new UserViewModel(user));
            }


            return View("Index", modelList);

        }

        [HttpGet]
        public ActionResult DeleteUser(int userid)
        {

            User user = UserRepository.LoadById(userid);
            UserViewModel model = new UserViewModel(user);

            return View(model);


        }


        // GET: Note
        [HttpPost]
        public ActionResult DeleteUser(UserViewModel model,long userid)
        {
            if (userid > 0)
            {
                User SaveUser = UserRepository.LoadById(userid);
                SaveUser.UserStatus = 2;
                UserRepository.Save(SaveUser);

                return Redirect("/User/Index");


            }
            else
            {
                return Redirect("/User/Index");
            }


        }

    }
}