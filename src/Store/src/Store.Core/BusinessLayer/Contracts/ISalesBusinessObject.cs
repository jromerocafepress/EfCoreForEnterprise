﻿using System;
using System.Threading.Tasks;
using Store.Core.BusinessLayer.Requests;
using Store.Core.BusinessLayer.Responses;
using Store.Core.DataLayer.DataContracts;
using Store.Core.EntityLayer.Dbo;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.BusinessLayer.Contracts
{
    public interface ISalesBusinessObject : IBusinessObject
    {
        Task<IPagingResponse<Customer>> GetCustomersAsync(Int32 pageSize = 10, Int32 pageNumber = 1);

        Task<IPagingResponse<Shipper>> GetShippersAsync(Int32 pageSize = 10, Int32 pageNumber = 1);

        Task<IPagingResponse<Currency>> GetCurrenciesAsync(Int32 pageSize = 10, Int32 pageNumber = 1);

        Task<IPagingResponse<PaymentMethod>> GetPaymentMethodsAsync(Int32 pageSize = 10, Int32 pageNumber = 1);

        Task<IPagingResponse<OrderInfo>> GetOrdersAsync(Int32 pageSize = 10, Int32 pageNumber = 1, Int16? currencyID = null, Int32? customerID = null, Int32? employeeID = null, Int16? orderStatusID = null, Guid? paymentMethodID = null, Int32? shipperID = null);

        Task<ISingleResponse<Order>> GetOrderAsync(Int32 id);

        Task<ISingleResponse<CreateOrderRequest>> GetCreateRequestAsync();

        Task<ISingleResponse<Order>> CreateOrderAsync(Order header, OrderDetail[] details);

        Task<ISingleResponse<Order>> CloneOrderAsync(Int32 id);

        Task<ISingleResponse<Order>> RemoveOrderAsync(Int32 id);
    }
}
