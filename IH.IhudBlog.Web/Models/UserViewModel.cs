using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        /// <summary>
        /// Дата Рождения
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        public UserViewModel()
        {

        }
        public UserViewModel(User user)
        {
            this.Id = user.Id;
            this.Login = user.Login;
            this.Password = user.Password;
            this.Email = user.Email;
            this.Birthday = user.Birthday;

        }


        static public string GetHash(string Str)
        {
            byte[] hash = Encoding.ASCII.GetBytes(Str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}
