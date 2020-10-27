using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.contactUs
{
    public class contactUsViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "لطفا شماره تلفن را وارد نمایید")]
        [Display(Name = "شماره تلفن")]
        public string phone { get; set; }
        [Required(ErrorMessage = "لطفا آدرس صفحه تلگرام را وارد نمایید")]
        [Display(Name = "آدرس صفحه تلگرام")]
        public string pageTelegramUrl { get; set; }
        [Required(ErrorMessage = "لطفا آدرس صفحه اینستاگرام را وارد نمایید")]
        [Display(Name = "آدرس صفحه اینستاگرام")]
        public string pageInstagramUrl { get; set; }
        [Required(ErrorMessage = "لطفا آدرس صفحه توییتر را وارد نمایید")]
        [Display(Name = "آدرس صفحه توییتر")]
        public string pageTwitterUrl { get; set; }
        [Required(ErrorMessage = "لطفا آدرس وب سایت را وارد نمایید")]
        [Display(Name = "آدرس وب سایت")]
        public string siteName { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل را وارد نمایید")]
        [Display(Name = "ایمیل")]
        public string email { get; set; }
       
    }
}