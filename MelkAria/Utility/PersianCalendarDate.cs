using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MelkAria.Utility
{
    public static class PersianCalendarDate
    {
        public static string PersianCalendarResult(DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(d) + "/" + pc.GetMonth(d).ToString().PadLeft(2, '0') + "/" + pc.GetDayOfMonth(d).ToString().PadLeft(2, '0');
        }
    }
}