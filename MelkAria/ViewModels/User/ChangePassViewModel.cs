using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.User
{
    public class ChangePassViewModel
    {
        [Required(ErrorMessage = "لطفا رمز عبور فعلی را وارد نمایید")]
        [Display(Name = "رمز عبور فعلی")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "لطفا رمز عبور جدید را وارد نمایید")]
        [Display(Name = "رمز عبور جدید")]
        public string NewPass { get; set; }
        [Required(ErrorMessage = "لطفا تکرار رمز عبور جدید را وارد نمایید")]
        [Display(Name = "تکرار رمز عبور جدید")]
        [CompareAttribute( "NewPass", ErrorMessage = "پسور یکسان نمی باشد!")]
        public string ConfirmNewPass { get; set; }

    }
}