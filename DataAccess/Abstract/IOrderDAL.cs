using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDAL : IEntityRepository<Order>
    {
         
        
         List<OrderDetailDTO> GetOrderDetails();//Gets All orders
         List<OrderDetailDTO> GetOrderDetailsByCustomerID(int ID);//Gets all order belongs to a customer
         OrderDetailDTO GetOrderDetailsByOrderID(int ID);//Gets order details belongs 
    }
}
