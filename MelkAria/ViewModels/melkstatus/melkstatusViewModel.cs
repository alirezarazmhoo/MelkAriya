using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.melkstatus
{
    public class melkstatusViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "لطفا عنوان را وارد نمایید")]
        [Display(Name = "عنوان")]
        public string title { get; set; }
    }
}