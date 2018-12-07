using RestaurantOrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantOrderApi.Business
{
    public class OrderBusiness
    {
        public static Order BuildOrder(string orderString)
        {
            Order orderFinal = new Order();
            List<string> dishes = new List<string>();

            //Dividing the string in period and dishNumbers
            //For the dishNumbers we already convert it to int to check the reference later
            string period = orderString.Substring(0, orderString.IndexOf(Constants.SEPARATOR))
                                       .Trim();
            List<int> dishesNumbers = orderString.Substring(orderString.IndexOf(Constants.SEPARATOR) + 1)
                                                    .Split(Constants.SEPARATOR)
                                                    .Select(val => val.Trim())
                                                    .Select(val => CheckAndConvert(val))
                                                    .ToList();
            dishesNumbers.Sort();

            //Building the list with the names of the dishes
            foreach (int dishNumber in dishesNumbers)
            {
                dishes.Add(Dishes.returnDish(period.ToUpper(), dishNumber));
            }

            orderFinal.originalOrder = orderString;
            orderFinal.finalOrder = BuildFinalOrder(dishes);

            return orderFinal;
        }

        //If we simply use convert we can get stuck trying to convert a letter into int
        private static int CheckAndConvert(string val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch(Exception ex)
            {
                throw new Exception("Could not convert string to int. String must have only numbers and separator after the dish period. " + ex);
            }
        }

        private static string BuildFinalOrder(List<string> dishes)
        {
            StringBuilder finalOrder = new StringBuilder();
            int repeatCount = 0;
            string previousChoice = "";

            foreach (string dish in dishes)
            {
                if (dish.Equals(previousChoice))
                {
                    //If the dish follows a forbidden rule we end the stream and return the string
                    if (IsForbidden(dish))
                    {
                        if (finalOrder.Length > 0) finalOrder.Append(Constants.SEPARATOR_FINAL);
                        finalOrder.Append(Constants.ERROR);
                        break;
                    }
                    else
                    {
                        //We only increment the count here, the count will be added later
                        repeatCount++;
                    }
                }
                else
                {
                    //Adding the count of repeated items
                    finalOrder.Append(RepeatString(repeatCount));
                    repeatCount = 0;
                    if (finalOrder.Length > 0) finalOrder.Append(Constants.SEPARATOR_FINAL);
                    finalOrder.Append(dish);

                    previousChoice = dish;
                }
            }

            //If the count still is not 0 we need to add the extra count 
            finalOrder.Append(RepeatString(repeatCount));
            return finalOrder.ToString();
        }

        private static bool IsForbidden(string dish)
        {
            //Current rule states that only coffee and potatoes can be repeated
            //This is in a different method and in different ifs to raise maintainability
            if (dish.Equals(Constants.MORNING_OPT3)) return false;
            if (dish.Equals(Constants.NIGHT_OPT2)) return false;
            return true;
        }

        private static string RepeatString(int count)
        {
            //0 Means never repeated, however if > 0 we need to considerate the first one, therefore +1
            if (count > 0)
            {
                count++;
                return "(x" + count +")";
            }
            return "";
        }
    }
}
