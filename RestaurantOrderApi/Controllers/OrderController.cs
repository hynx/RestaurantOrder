using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RestaurantOrderApi.Models;
using RestaurantOrderApi.Business;

namespace RestaurantOrderApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetOrder")]
        public ActionResult<List<Order>> GetAll()
        {
            return _context.Order.OrderByDescending(s => s.id).ToList();
        }

        [HttpPost]
        public ActionResult Create(Order orderReceived)
        {
            string orderString = orderReceived.originalOrder;
            if (!orderString.ToUpper().StartsWith(Constants.MORNING) && !orderString.ToUpper().StartsWith(Constants.NIGHT))
            {
                return BadRequest("The request must start with " + Constants.MORNING + " or " + Constants.NIGHT);
            }
            Order orderInsert = OrderBusiness.BuildOrder(orderString);
            _context.Order.Add(orderInsert);
            _context.SaveChanges();

            return CreatedAtRoute("GetOrder", new { id = orderInsert.id }, orderInsert);
        }
    }
}