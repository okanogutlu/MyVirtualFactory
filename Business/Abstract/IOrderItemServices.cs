using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderItemServices
    {
        IDataResult<List<OrderItem>> GetAll(); //Tüm orderItemleri  getir.
        IDataResult<OrderItem> GetByID(int ID);//ID ile orderItem getir.
        IDataResult<OrderItem> GetByOrderID(int ID);//OrderID ile OrderItem getir.
        IDataResult<List<OrderItem>> GetByProductID(int ID);//ProductID ile orderItemleri getir.
        IDataResult<List<OrderItemDetailDTO>> GetOrderItemDetails();
        IDataResult<OrderItemDetailDTO> GetOrderItemDetailsByOrderID(int ID);
        IDataResult<OrderItemDetailDTO> GetOrderItemDetailsByOrderItemID(int ID);
        IResult Add(OrderItem orderItem);
        IResult Update(OrderItem orderItem);
    }
}
