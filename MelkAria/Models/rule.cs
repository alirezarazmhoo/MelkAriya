using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public class rule
    {
         public int id { get; set; }
        [MaxLength(50)]
        public string title { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
    }
}