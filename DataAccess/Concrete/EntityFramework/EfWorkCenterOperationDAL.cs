using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWorkCenterOperationDAL : EfEntityRepositoryBase<WorkCenterOperation, MSSQLDbContext>, IWorkCenterOperationDAL
    {
        public List<WorkCenterOperationsDetailDTO> GetWorkCenterOperationDetails()
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
