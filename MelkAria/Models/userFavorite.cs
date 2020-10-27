using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public class userFavorite
    {
        public int id { get; set; }
        [ForeignKey("melk")]
        public int melkId { get; set; }
        public virtual melk melk { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public virtual user user { get; set; }
    }
}