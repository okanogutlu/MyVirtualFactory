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
    public class EfStockDAL : EfEntityRepositoryBase<Stock, MSSQLDbContext>, IStockDAL
    {
        public List<StockDetailDTO> GetStockDetails()
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.Stocks
                             join c in context.Products
                             on p.ProductID equals c.ProductID
                             select new StockDetailDTO
                             {
                                AmountOfStock=p.AmountOfStock,
                                ProductID=c.ProductID,
                                ProductName=c.ProductName,
                                ProductTypeName=c.ProductType
                             };
                return result.ToList();
            }
        }
    }
}
