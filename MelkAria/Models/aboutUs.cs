using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public class aboutUs
    {
        public int id { get; set; }
        [MaxLength(50)]
        public string title { get; set; }
        [MaxLength(20)]
        public string androidVersion { get; set; }
         [MaxLength(20)]
        public string author { get; set; }
         [MaxLength(1000)]
        public string description { get; set; }
    }
}