using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.Home
{
    public class HomeSingleViewModel
    {
        public MelkAria.Models.melk melk { get; set; }
        public List<MelkAria.Models.melk> Lastmelks { get; set; }
        public List<MelkAria.Models.photo> photos { get; set; }
    }
}