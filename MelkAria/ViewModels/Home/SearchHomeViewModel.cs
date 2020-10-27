using MelkAria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.Home
{
    public class SearchHomeViewModel
    {
        public long? fromPrice { get; set; }
        public long? toPrice { get; set; }
        public int? roomCount { get; set; }
        public EnumMelkKind? kind { get; set; }
        public string address { get; set; }
        public int page { get; set; }
        public int statusKind { get; set; }
        public long? code { get; set; }


    }
}