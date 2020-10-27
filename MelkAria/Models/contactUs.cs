using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MelkAria.Models
{
    public class contactUs
    {
         public int id { get; set; }
        [MaxLength(50)]
        public string phone { get; set; }
        [MaxLength(200)]
        public string pageTelegramUrl { get; set; }
         [MaxLength(200)]
        public string pageInstagramUrl { get; set; }
         [MaxLength(200)]
        public string pageTwitterUrl { get; set; }
         [MaxLength(100)]
        public string siteName { get; set; }
         [MaxLength(50)]
        public string email { get; set; }
    }
}