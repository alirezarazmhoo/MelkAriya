using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public class photo
    {
        public int id { get; set; }
       
        [Display(Name ="انتخاب فایل")]  
        public string file { get; set; }
        [ForeignKey("melk")]
        public int melkId { get; set; }
        public virtual melk melk { get; set; }
    }
}