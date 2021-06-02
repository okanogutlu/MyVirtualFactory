using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderItemDAL : EfEntityRepositoryBase<OrderItem, MSSQLDbContext>, IOrderItemDAL
    {
        public List<OrderItemDetailDTO> GetOrderItemDetails()
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.OrderItems
                             join c in context.Orders
                             on p.OrderID equals c.OrderID

                             select new OrderItemDetailDTO
                             {
                                 Amount = p.Amount,
                                 OrderID = p.OrderID,
                                 OrderItemID = p.orderItemID,
                                 ProductName = (context.Products.FirstOrDefault(a => a.ProductID == p.ProductID).ProductName),
                             };
                return result.ToList();
            }
        }

        public OrderItemDetailDTO GetOrderItemDetailsByOrderID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.OrderItems
                             join c in context.Orders
                             on p.OrderID equals c.OrderID
                             where c.OrderID == ID
                             select new OrderItemDetailDTO
                             {
                                 Amount = p.Amount,
                                 OrderID = p.OrderID,
                                 OrderItemID = p.orderItemID,
                                 ProductName = (context.Products.FirstOrDefault(a => a.ProductID == p.ProductID).ProductName),
                             };
                return (OrderItemDetailDTO)result;
            }
        }

        public OrderItemDetailDTO GetOrderItemDetailsByOrderItemID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.OrderItems
                             join c in context.Orders
                             on p.OrderID equals c.OrderID
                             where p.orderItemID == ID
                             select new OrderItemDetailDTO
                             {
                                 Amount = p.Amount,
                                 OrderID = p.OrderID,
                                 OrderItemID = p.orderItemID,
                                 ProductName = (context.Products.FirstOrDefault(a => a.ProductID == p.ProductID).ProductName),
                             };
                return (OrderItemDetailDTO)result;
            }
        }
    }
}
