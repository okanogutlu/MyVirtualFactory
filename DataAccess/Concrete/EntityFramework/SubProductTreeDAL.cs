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
    public class EfSubProductTreeDAL : EfEntityRepositoryBase<SubProductTree, MSSQLDbContext>, ISubProductTreeDAL
    {
        public List<SubProductTreeDetailDTO> GetSubProductTreeDetails()
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.SubProductTrees
                             join c in context.Products
                             on p.ProductID equals c.ProductID
                             select new SubProductTreeDetailDTO
                             {
                                 Amount = p.Amount,
                                 ProductID = p.ProductID,
                                 ProductName = c.ProductName,
                                 ProductTypeName = c.ProductType,
                                 SubProductID = p.SubProductID
                             };
                return result.ToList();
            }
        }

        public List<SubProductTreeDetailDTO> GetSubProductTreeDetailsByID(int ID)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.SubProductTrees
                             join c in context.Products
                             on p.ProductID equals c.ProductID
                             where p.SubProductID == ID
                             select new SubProductTreeDetailDTO
                             {
                                 Amount = p.Amount,
                                 ProductID = p.ProductID,
                                 ProductName = c.ProductName,
                                 ProductTypeName = c.ProductType,
                                 SubProductID = p.SubProductID
                             };
                return result.ToList();
            }
        }

        public List<SubProductTreeDetailDTO> GetSubProductTreeDetailsByProductName(string Name)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.SubProductTrees
                             join c in context.Products
                             on p.ProductID equals c.ProductID
                             where c.ProductName.Equals(Name)
                             select new SubProductTreeDetailDTO
                             {
                                 Amount = p.Amount,
                                 ProductID = p.ProductID,
                                 ProductName = c.ProductName,
                                 ProductTypeName = c.ProductType,
                                 SubProductID = p.SubProductID
                             };
                return result.ToList();
            }
        }
    }
}
