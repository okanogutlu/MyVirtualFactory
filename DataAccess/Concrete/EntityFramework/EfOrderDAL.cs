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
    public class EfOrderDAL : EfEntityRepositoryBase<Order, MSSQLDbContext>, IOrderDAL
    {

        public List<OrderDetailDTO> GetOrderDetails()
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Orders
                             join c in context.Users
                             on p.UserID equals c.ID
                             select new OrderDetailDTO
                             {
                                 CustomerID = p.UserID,
                                 CustomerName = c.FirstName,
                                 CustomerSurname = c.LastName,
                                 Deadline = p.Deadline,
                                 OrderDate = p.OrderDate,
                                 OrderID = p.OrderID,
                                 OrderItem = (from a in context.OrderItems
                                              where a.OrderID == p.OrderID
                                              select new OrderItem
                                              {
                                                  Amount = a.Amount,
                                                  OrderID = a.OrderID,
                                                  orderItemID = a.orderItemID,
                                                  ProductID = a.ProductID,
                                              }).ToList(),
                                 OrderStatus = p.OrderStatus
                             };
                return result.ToList();
            }
        }

        public List<OrderDetailDTO> GetOrderDetailsByCustomerID(int ID)
        {
            EfOrderItemDAL forOrderItem = new EfOrderItemDAL();
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Orders
                             join c in context.Users
                             on p.UserID equals c.ID
                             where c.ID == ID

                             select new OrderDetailDTO
                             {
                                 CustomerID = p.UserID,
                                 CustomerName = c.FirstName,
                                 CustomerSurname = c.LastName,
                                 Deadline = p.Deadline,
                                 OrderDate = p.OrderDate,
                                 OrderID = p.OrderID,
                                 OrderStatus = p.OrderStatus,
                                 OrderItem = (from a in context.OrderItems
                                              where a.OrderID == p.OrderID
                                              select new OrderItem
                                              {
                                                  Amount = a.Amount,
                                                  OrderID = a.OrderID,
                                                  orderItemID = a.orderItemID,
                                                  ProductID = a.ProductID,
                                                  Product = context.Products.FirstOrDefault(p => p.ProductID == a.ProductID)
                                              }).ToList()
                                 
                             };
                return result.ToList();
            }
        }

        public OrderDetailDTO GetOrderDetailsByOrderID(int ID) //burayı liste ye çekelim
        {
            EfOrderItemDAL forOrderItem = new EfOrderItemDAL();
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Orders
                             join c in context.Users
                             on p.UserID equals c.ID
                             where p.OrderID == ID

                             select new OrderDetailDTO
                             {
                                 CustomerID = p.UserID,
                                 CustomerName = c.FirstName,
                                 CustomerSurname = c.LastName,
                                 Deadline = p.Deadline,
                                 OrderDate = p.OrderDate,
                                 OrderID = p.OrderID,
                                 OrderStatus = p.OrderStatus,
                                 OrderItem = (from a in context.OrderItems
                                              where a.OrderID == p.OrderID
                                              select new OrderItem
                                              {
                                                  Amount = a.Amount,
                                                  OrderID = a.OrderID,
                                                  orderItemID = a.orderItemID,
                                                  ProductID = a.ProductID,
                                              }).ToList()
                             };
                return result.First();//!
            }
        }
  
    }
}
