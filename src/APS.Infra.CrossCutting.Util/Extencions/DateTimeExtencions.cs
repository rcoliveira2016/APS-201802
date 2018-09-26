using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Infra.CrossCutting.Util.Extencions
{
    public static class DateTimeExtencions
    {
        public static bool Between(this DateTime value, DateTime date1, DateTime date2)
        {
            return (value > date1 && value < date2);
        }

        public static DateTime FirstDayMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1,0,0,0);
        }

        public static DateTime LastDayMonth(this DateTime value)
        {
            return FirstDayMonth(value).AddMonths(1).AddDays(-1);
        }
    }
}
