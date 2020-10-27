using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.city
{
    public class cityViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "لطفا نام استان را وارد نمایید")]
        [Display(Name = "نام استان")]
        public string name { get; set; }
        [Required(ErrorMessage = "لطفا نام لاتین استان را وارد نمایید")]
        [Display(Name = "نام لاتین استان")]
        public string nameEnglish { get; set; }
        
    }
}