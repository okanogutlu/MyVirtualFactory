using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDTO
                             {
                                 CategoryName = c.CategoryName,
                                 ProdutID = p.ProductID,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock

                             };
                return result.ToList();
            }
        }

        public List<OrderDetailDTO> GetOrderDetailsByCustomerID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Orders
                             join c in context.Users
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDTO
                             {
                                 CategoryName = c.CategoryName,
                                 ProdutID = p.ProductID,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock

                             };
                return result.ToList();
            }
        }

        public OrderDetailDTO GetOrderDetailsByOrderID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Orders
                             join c in context.Users
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDTO
                             {
                                 CategoryName = c.CategoryName,
                                 ProdutID = p.ProductID,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock

                             };
                return result.ToList();
            }
        }
    }
}
