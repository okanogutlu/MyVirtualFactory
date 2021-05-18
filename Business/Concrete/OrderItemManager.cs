using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderItemManager:IOrderItemServices
    {
        
        IOrderItemDAL _orderItemDAL;
        public OrderItemManager(IOrderItemDAL orderItemDAL) => _orderItemDAL = orderItemDAL;

        public IResult Add(OrderItem orderItem)
        {
            _orderItemDAL.Add(orderItem);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<OrderItem>> GetAll()
        {
            return new SuccessDataResult<List<OrderItem>>(_orderItemDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<OrderItem> GetByID(int ID)
        {
            return new SuccessDataResult<OrderItem>(_orderItemDAL.Get(p => p.orderItemID == ID));
        }

        public IDataResult<OrderItem> GetByOrderID(int ID)
        {
            return new SuccessDataResult<OrderItem>(_orderItemDAL.Get(p => p.OrderID == ID));
        }

        public IDataResult<List<OrderItem>> GetByProductID(int ID)
        {
            return new SuccessDataResult<List<OrderItem>>(_orderItemDAL.GetAll(p=>p.ProductID==ID), "Successfully Listed");
        }

        public IDataResult<List<OrderItemDetailDTO>> GetOrderItemDetails()
        {
            return new SuccessDataResult<List<OrderItemDetailDTO>>(_orderItemDAL.GetOrderItemDetails());
        }

        public IDataResult<OrderItemDetailDTO> GetOrderItemDetailsByOrderID(int ID)
        {
            return new SuccessDataResult<OrderItemDetailDTO>(_orderItemDAL.GetOrderItemDetailsByOrderID(ID));
        }

        public IDataResult<OrderItemDetailDTO> GetOrderItemDetailsByOrderItemID(int ID)
        {
            return new SuccessDataResult<OrderItemDetailDTO>(_orderItemDAL.GetOrderItemDetailsByOrderItemID(ID));
        }

        public IResult Update(OrderItem orderItem)
        {
            _orderItemDAL.Update(orderItem);
            return new SuccessResult("Successfully Updated");
        }
    }
}
