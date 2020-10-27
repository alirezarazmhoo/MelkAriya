using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.melk
{
    public class LoadmelkDataViewModel
    {
        public List<MelkAria.Models.melk> melks { get; set; }
        public int TotalNumber { get; set; }
    }
}