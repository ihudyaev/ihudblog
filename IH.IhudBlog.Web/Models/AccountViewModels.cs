//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet;


//namespace IH.IhudBlog.Web.Models
//{
   
//    public class IndexViewModel
//    {
//        public bool HasPassword { get; set; }
//        public IList<UserLoginInfo> Logins { get; set; }
//        public string PhoneNumber { get; set; }
//        public bool BrowserRemembered { get; set; }
//    }
    
//    public class SetPasswordViewModel
//    {
//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Новый пароль")]
//        public string NewPassword { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Подтверждение нового пароля")]
//        [Compare("Новый пароль", ErrorMessage = "Новый пароль и подтверждение не совпадают.")]
//        public string ConfirmPassword { get; set; }
//    }

//    public class ChangePasswordViewModel
//    {
//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Текущий пароль")]
//        public string OldPassword { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = " {0} должен быть не менее {2} символов длиной.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Новый пароль")]
//        public string NewPassword { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Подтверждение нового пароля")]
//        [Compare("Новый пароль", ErrorMessage = "Новый пароль и подтверждение не совпадают.")]
//        public string ConfirmPassword { get; set; }
//    }

//}