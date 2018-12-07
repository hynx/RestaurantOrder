using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderApi.Business
{
    public static class Constants
    {
        //Periods
        public const string NIGHT = "NIGHT";
        public const string MORNING = "MORNING";

        //Morning Options
        public const string MORNING_OPT1 = "Eggs";
        public const string MORNING_OPT2 = "Toast";
        public const string MORNING_OPT3 = "Coffee";

        //Night Options
        public const string NIGHT_OPT1 = "Steak";
        public const string NIGHT_OPT2 = "Potato";
        public const string NIGHT_OPT3 = "Wine";
        public const string NIGHT_OPT4 = "Cake";

        //Other consts
        public const string ERROR = "Error";
        public const string SEPARATOR = ",";
        public const string SEPARATOR_FINAL = ", ";
    }
}
