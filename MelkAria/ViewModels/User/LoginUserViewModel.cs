using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.User
{
    public class LoginUserViewModel
    {

        //[RegularExpression(@"(.{10})", ErrorMessage = "کد ملی باید شامل 10 عدد باشد")]
        //[Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        //public string CodeMeli { get; set; }
        //[RegularExpression(@"(.{10})", ErrorMessage = "کد ملی باید شامل 10 عدد باشد")]
        //[Required(ErrorMessage = "لطفا کد ملی معرف را وارد نمایید")]
        //public string ParentCodeMeli { get; set; }
        //[RegularExpression(@"(.{11})", ErrorMessage = "تلفن همراه باید شامل 11 عدد باشد")]
        [Required(ErrorMessage = "لطفا تلفن همراه را وارد نمایید")]
        public string Mobile { get; set; }
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        public string UserNamee { get; set; }
        //[StringLength(1000, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا جواب جمع را وارد نمایید")]
        [Display(Name = "جواب جمع")]
        public string Captcha { get; set; }
        public string Email { get; set; }
        public string name { get; set; }
        public string family { get; set; }

    }
}