using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestaurantOrderApi.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderApi.Models
{
    public class OrderContextFake : OrderContext
    {
        private List<Order> listOrders;
        private int counter = 4;
        static DbContextOptions<OrderContext> options = new DbContextOptions<OrderContext>();

        public OrderContextFake()
            : base(options)
        {
            listOrders = new List<Order>()
            {
                new Order() { id = 1, originalOrder = "night, 1, 2, 3", finalOrder = "Steak, Potato, Wine" },
                new Order() { id = 2, originalOrder = "morning, 1, 2, 3", finalOrder = "Eggs, Toast, Coffee" },
                new Order() { id = 3, originalOrder = "morning, 1, 2, 4", finalOrder = "Eggs, Toast, Error" }
            };
        }

        public List<Order> GetAll()
        {
            return listOrders;
        }

        public Order Create(Order newItem)
        {
            newItem.id = counter;
            counter++;
            Order auxOrder = OrderBusiness.BuildOrder(newItem.originalOrder);
            newItem.finalOrder = auxOrder.finalOrder;
            listOrders.Add(newItem);
            return newItem;
        }
    }
}
