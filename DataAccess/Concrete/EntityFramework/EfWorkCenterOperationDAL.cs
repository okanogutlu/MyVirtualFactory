using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.Enums;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWorkCenterOperationDAL : EfEntityRepositoryBase<WorkCenterOperation, MSSQLDbContext>, IWorkCenterOperationDAL
    {
        public List<WorkCenterOperationsDetailDTO> GetWorkCenterOperationDetails()
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.WorkCenterOperations
                             join c in context.Operations
                             on p.OperationID equals c.OperationID
                             select new WorkCenterOperationsDetailDTO
                             {
                                OperationID=p.OperationID,
                                OperationName=c.OperationName,
                                ProductType=c.ProductTypes,
                                Speed=p.Speed,
                                WorkCenterID=p.WorkCenterID,
                                WorkCenterName=(context.WorkCenters.FirstOrDefault(a=>a.WorkCenterID==p.WorkCenterID).WorkCenterName),
                                WorkCenterOperationID=p.WcOprID,

                             };
                return result.ToList();
            }
        }

        public List<WorkCenterOperationsDetailDTO> GetWorkCenterOperationDetailsByOperationName(string operationName)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.WorkCenterOperations
                             join c in context.Operations
                             on p.OperationID equals c.OperationID
                             where c.OperationName==operationName
                             select new WorkCenterOperationsDetailDTO
                             {
                                 OperationID = p.OperationID,
                                 OperationName = c.OperationName,
                                 ProductType = c.ProductTypes,
                                 Speed = p.Speed,
                                 WorkCenterID = p.WorkCenterID,
                                 WorkCenterName = (context.WorkCenters.FirstOrDefault(a => a.WorkCenterID == p.WorkCenterID).WorkCenterName),
                                 WorkCenterOperationID = p.WcOprID,

                             };
                return result.ToList();
            }
        }

        public List<WorkCenterOperationsDetailDTO> GetWorkCenterOperationDetailsByProductType(string ProductType)
        {
            ProductTypes type = (ProductTypes)System.Enum.Parse(typeof(ProductTypes), ProductType);
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.WorkCenterOperations
                             join c in context.Operations
                             on p.OperationID equals c.OperationID
                             where c.ProductTypes == type
                             select new WorkCenterOperationsDetailDTO
                             {
                                 OperationID = p.OperationID,
                                 OperationName = c.OperationName,
                                 ProductType = c.ProductTypes,
                                 Speed = p.Speed,
                                 WorkCenterID = p.WorkCenterID,
                                 WorkCenterName = (context.WorkCenters.FirstOrDefault(a => a.WorkCenterID == p.WorkCenterID).WorkCenterName),
                                 WorkCenterOperationID = p.WcOprID,

                             };
                return result.ToList();
            }
        }

        public List<WorkCenterOperationsDetailDTO> GetWorkCenterOperationDetailsbyWorkCenterName(string workcentername)
        {
            using (MSSQLDbContext context = new MSSQLDbContext())

            {
                var result = from p in context.WorkCenterOperations
                             join c in context.Operations
                             on p.OperationID equals c.OperationID
                             where (context.WorkCenters.FirstOrDefault(p=>p.WorkCenterID==p.WorkCenterID).WorkCenterName) == workcentername
                             select new WorkCenterOperationsDetailDTO
                             {
                                 OperationID = p.OperationID,
                                 OperationName = c.OperationName,
                                 ProductType = c.ProductTypes,
                                 Speed = p.Speed,
                                 WorkCenterID = p.WorkCenterID,
                                 WorkCenterName = (context.WorkCenters.FirstOrDefault(a => a.WorkCenterID == p.WorkCenterID).WorkCenterName),
                                 WorkCenterOperationID = p.WcOprID,

                             };
                return result.ToList();
            }
        }
    }
}
