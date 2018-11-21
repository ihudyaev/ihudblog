using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IH.IhudBlog.Core.Models;

namespace IH.IhudBlog.Web.Models
{



    public class UserViewModel
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        public UserViewModel()
        {

        }
        public UserViewModel(User user)
        {
            this.Id = user.Id;
            this.Login = user.Login;
            this.Password = user.Password;

        }
    }
}
