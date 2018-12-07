using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderApi.Controllers;
using RestaurantOrderApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitRestarantOrder
{
    public class OrderControllerTest
    {
        OrderContextFake _controller = new OrderContextFake();

        public OrderControllerTest()
        {
            _controller = new OrderContextFake();
        }

        [Fact]
        public void Get_Request_ReturnAllItems()
        {
            List<Order> result = _controller.GetAll();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            Order testItem = new Order()
            {
                originalOrder = "morning, 1, 2, 3"
            };

            var createdResponse = _controller.Create(testItem);
            Assert.IsType<Order>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Order()
            {
                originalOrder = "morning, 1, 2, 3, 3, 3"
            };

            // Act
            var createdResponse = _controller.Create(testItem) as Order;

            // Assert
            Assert.IsType<Order>(createdResponse);
            Assert.Equal("Eggs, Toast, Coffee(x3)", createdResponse.finalOrder);
        }
    }
}
