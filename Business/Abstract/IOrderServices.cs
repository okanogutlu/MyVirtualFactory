using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderServices
    {
        IDataResult<List<Order>> GetAll(); //Tüm Order getir.
        IDataResult<Order> GetByID(int ID);//ID ile Order getir.
        IDataResult<Order> GetByCustomerID(int customerID);//ID ile Order getir.
        IDataResult<List<Order>> GetByOrderDate(DateTime orderDate);//ID ile Order getir.
        IDataResult<List<Order>> GetByOrderDeadline(DateTime deadLine);//ID ile Order getir.
        IDataResult<List<Order>> GetAllDeadLineUntilNow(DateTime deadline);//O zamana kadar ki tüm deadlinelı orderları getirir.
        IDataResult<List<Order>> GetAllOrderDateUntilNow(DateTime orderDate);//O zamana kadar ki tüm orderdateli orderları getirir.
        IDataResult<List<OrderDetailDTO>> GetOrderDetails();//Gets All orders
        IDataResult<List<OrderDetailDTO>> GetOrderDetailsByCustomerID(int ID);//Gets all order belongs to a customer
        IDataResult<OrderDetailDTO> GetOrderDetailsByOrderID(int ID);//Gets order details belongs 
        IResult Add(Order order);
        IResult Update(Order order);
    }
}
