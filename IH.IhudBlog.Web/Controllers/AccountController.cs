using System.Web.Mvc;
using System.Web.Security;
using IH.IhudBlog.Core.Repository.Interface;
using IH.IhudBlog.Core.NHibernate;
using IH.IhudBlog.Web.Models;




namespace IH.IhudBlog.Web.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        IUserRepository UserRepository;

        public AccountController()
        {
            UserRepository = new NHUserRepository();
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Что-то пошло не так! 😊");
                return View(model);
            }

            var user = UserRepository.LoadByName(model.Login);

            if (user == null || user.Password != UserViewModel.GetHash(model.Password))
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(user.Login, false);

            return RedirectToAction("Index", "Note");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }

}
