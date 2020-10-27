using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.melkstatus
{
    public class LoadmelkstatusDataViewModel
    {
        public List<MelkAria.Models.melkstatus> melkstatuss { get; set; }
        public int TotalNumber { get; set; }
    }
}