using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.aboutUs
{
    public class aboutUsViewModel
    {
         public int id { get; set; }
        [Required(ErrorMessage = "لطفا توضیحات را وارد نمایید")]
        [Display(Name = "توضیحات")]
        public string description { get; set; }
        [Required(ErrorMessage = "لطفا نویسنده اندروید را وارد نمایید")]
        [Display(Name = "نویسنده اندروید")]
        public string author { get; set; }
        [Required(ErrorMessage = "لطفا عنوان را وارد نمایید")]
        [Display(Name = "عنوان")]
        public string title { get; set; }
        [Required(ErrorMessage = "لطفا ورژن اندروید را وارد نمایید")]
        [Display(Name = "ورژن اندروید")]
        public string androidVersion { get; set; }
    }
}