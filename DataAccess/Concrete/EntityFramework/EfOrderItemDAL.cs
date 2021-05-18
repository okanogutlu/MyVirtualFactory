using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderItemDAL : EfEntityRepositoryBase<OrderItem, MSSQLDbContext>, IOrderItemDAL
    {
        public List<OrderItemDetailDTO> GetOrderItemDetails()
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Products
                             join c in context.Categories
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

        public OrderItemDetailDTO GetOrderItemDetailsByOrderID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Products
                             join c in context.Categories
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

        public OrderItemDetailDTO GetOrderItemDetailsByOrderItemID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Products
                             join c in context.Categories
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
