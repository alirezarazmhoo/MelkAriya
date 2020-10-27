using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public class role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleNameFa { get; set; }
        [Required]
        public string RoleNameEn{ get; set; }
        public List<user> Users{ get; set; }
    }
}