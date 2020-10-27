using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public class user
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(200)]
        public string family { get; set; }
        [MaxLength(11)]
        public string mobile { get; set; }
        [MaxLength(20)]
        public string userNamee { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(1000)]
        public string password { get; set; }
        [MaxLength(20)]
        public string passwordShow { get; set; }
        [MaxLength(100)]
        public string apiToken { get; set; }
       
        public role role { get; set; }
         [MaxLength(70)]
        public string image { get; set; }

    }
}