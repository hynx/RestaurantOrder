using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderApi.Business
{
    public class Dishes
    {
        public static string returnDish(string dishPeriod, int dishNumber)
        {
            if(dishPeriod.ToUpper().Equals(Constants.MORNING))
            {
                switch(dishNumber)
                {
                    case 1: return Constants.MORNING_OPT1;
                    case 2: return Constants.MORNING_OPT2;
                    case 3: return Constants.MORNING_OPT3;
                    default : return Constants.ERROR;
                }
            }
            else if (dishPeriod.ToUpper().Equals(Constants.NIGHT))
            {
                switch (dishNumber)
                {
                    case 1: return Constants.NIGHT_OPT1;
                    case 2: return Constants.NIGHT_OPT2;
                    case 3: return Constants.NIGHT_OPT3;
                    case 4: return Constants.NIGHT_OPT4;
                    default: return Constants.ERROR;
                }
            }

            return "error";
        }
    }
}
