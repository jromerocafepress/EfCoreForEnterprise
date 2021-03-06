﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.API.Controllers;
using Store.Core.BusinessLayer.Requests;
using Store.Core.BusinessLayer.Responses;
using Store.Core.DataLayer.DataContracts;
using Store.Core.EntityLayer.Sales;
using Xunit;

namespace Store.API.Tests
{
    public class SalesControllerTests
    {
        [Fact]
        public async Task TestGetOrdersAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<SalesController>();
            var humanResourcesBusinessObject = BusinessObjectMocker.GetHumanResourcesBusinessObject();
            var productionBusinessObject = BusinessObjectMocker.GetProductionBusinessObject();
            var salesBusinessObject = BusinessObjectMocker.GetSalesBusinessObject();

            using (var controller = new SalesController(logger, humanResourcesBusinessObject, productionBusinessObject, salesBusinessObject))
            {
                // Act
                var response = await controller.GetOrdersAsync() as ObjectResult;
                var value = response.Value as IPagingResponse<OrderInfo>;

                // Assert
                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetOrderAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<SalesController>();
            var humanResourcesBusinessObject = BusinessObjectMocker.GetHumanResourcesBusinessObject();
            var productionBusinessObject = BusinessObjectMocker.GetProductionBusinessObject();
            var salesBusinessObject = BusinessObjectMocker.GetSalesBusinessObject();
            var id = 1;

            using (var controller = new SalesController(logger, humanResourcesBusinessObject, productionBusinessObject, salesBusinessObject))
            {
                // Act
                var response = await controller.GetOrderAsync(id) as ObjectResult;
                var value = response.Value as ISingleResponse<Order>;

                // Assert
                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetNonExistingOrderAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<SalesController>();
            var humanResourcesBusinessObject = BusinessObjectMocker.GetHumanResourcesBusinessObject();
            var productionBusinessObject = BusinessObjectMocker.GetProductionBusinessObject();
            var salesBusinessObject = BusinessObjectMocker.GetSalesBusinessObject();
            var id = 0;

            using (var controller = new SalesController(logger, humanResourcesBusinessObject, productionBusinessObject, salesBusinessObject))
            {
                // Act
                var response = await controller.GetOrderAsync(id) as ObjectResult;
                var value = response.Value as ISingleResponse<Order>;

                // Assert
                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetCreateOrderRequestAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<SalesController>();
            var humanResourcesBusinessObject = BusinessObjectMocker.GetHumanResourcesBusinessObject();
            var productionBusinessObject = BusinessObjectMocker.GetProductionBusinessObject();
            var salesBusinessObject = BusinessObjectMocker.GetSalesBusinessObject();

            using (var controller = new SalesController(logger, humanResourcesBusinessObject, productionBusinessObject, salesBusinessObject))
            {
                // Act
                var response = await controller.GetCreateOrderRequestAsync() as ObjectResult;
                var value = response.Value as ISingleResponse<CreateOrderRequest>;

                // Assert
                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestCloneOrderAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<SalesController>();
            var humanResourcesBusinessObject = BusinessObjectMocker.GetHumanResourcesBusinessObject();
            var productionBusinessObject = BusinessObjectMocker.GetProductionBusinessObject();
            var salesBusinessObject = BusinessObjectMocker.GetSalesBusinessObject();
            var id = 1;

            using (var controller = new SalesController(logger, humanResourcesBusinessObject, productionBusinessObject, salesBusinessObject))
            {
                // Act
                var response = await controller.CloneOrderAsync(id) as ObjectResult;
                var value = response.Value as ISingleResponse<Order>;

                // Assert
                Assert.False(value.DidError);
            }
        }
    }
}
