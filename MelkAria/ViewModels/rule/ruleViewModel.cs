using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.rule
{
    public class ruleViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "لطفا عنوان را وارد نمایید")]
        [Display(Name = "عنوان")]
        public string title { get; set; }
        [Required(ErrorMessage = "لطفا توضیحات را وارد نمایید")]
        [Display(Name = "توضیحات")]
        public string description { get; set; }
    }
}