using System;
using System.Security.Cryptography;
using System.Text;
using IH.IhudBlog.Core.Models;
using System.ComponentModel.DataAnnotations;


namespace IH.IhudBlog.Web.Models
{



    public class UserViewModel
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        /// 
        public long Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        /// 
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        /// 
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        
        public string Password { get; set; }
        /// <summary>
        /// Дата Рождения
        /// </summary>
        /// 
        [DataType(DataType.Date)]
        [Display(Name = "Дата Рождения")]
        [Required(ErrorMessage = "Введите дату рождение")]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        /// 
        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Введите адрес почты")]
        [EmailAddress(ErrorMessage = "Введите корректный адрес почты")]
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

        public static User Conversion(UserViewModel user)
        {
            //var StartData = Note.GetNotes();
            
            User result = new User
            {
                Id = (long)user.Id,
                Password = user.Password,
                Login = user.Login,
                UserStatus = 1,
                Email = user.Email,
                Birthday = (DateTime)(user.Birthday == null ? DateTime.Now : user.Birthday) 

            };

            return result;
        }
    }
}
