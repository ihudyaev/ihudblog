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
        public ActionResult Index()
        {
            IEnumerable<User> all = UserRepository.GetAll();
            List<UserViewModel> model = new List<UserViewModel>();
            foreach (User user in all)
            {
                model.Add(new UserViewModel(user));
            }
            return View(model);
        }
    }
}