using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderApi.Models
{
    public class Order
    {
        public long id { get; set; }
        public string originalOrder { get; set; }
        public string finalOrder { get; set; }
    }
}
