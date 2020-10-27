using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.rule
{
    public class LoadruleDataViewModel
    {
        public List<MelkAria.Models.rule> rules { get; set; }
        public int TotalNumber { get; set; }
    }
}