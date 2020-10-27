using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.User
{
    public class LoadUserDataViewModel
    {
        public List<MelkAria.Models.user> Users { get; set; }
        public int TotalNumber { get; set; }
    }
}