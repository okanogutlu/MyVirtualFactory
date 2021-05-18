using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderItemDAL:IEntityRepository<OrderItem>
    {
        List<OrderItemDetailDTO> GetOrderItemDetails();
        OrderItemDetailDTO GetOrderItemDetailsByOrderID(int ID);
        OrderItemDetailDTO GetOrderItemDetailsByOrderItemID(int ID);

    }
}
