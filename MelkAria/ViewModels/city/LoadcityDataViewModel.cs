using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.city
{
    public class LoadcityDataViewModel
    {
        public List<MelkAria.Models.city> cities { get; set; }
        public int TotalNumber { get; set; }
    }
}