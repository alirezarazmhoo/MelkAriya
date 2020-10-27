using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.melk
{
    public class additionalInfoViewModel
    {
        public int id { get; set; }
        [Display(Name ="انتخاب فایل")]  
        public HttpPostedFileBase[] files { get; set; }
        public List<Models.photo> photos { get; set; }
        public Models.melk melk { get; set; }
    }
}