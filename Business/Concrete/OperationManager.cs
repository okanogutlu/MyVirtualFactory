using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    // *İki tane aynı isimli operationtype olmamalı *aynı isimli operasyon adı olmamalı
    public class OperationManager:IOperationServices
    {
        IOperationDAL _operationDAL;

        public OperationManager(IOperationDAL operationDAL) => _operationDAL = operationDAL;

        public IResult Add(Operation operation)
        {
            //operation.ProductTypes=Entities.Concrete.Enums.ProductTypes.
            var result = BusinessRules.Run(
               CheckIfHaveAlreadySameProductType(operation.ProductTypes),
               CheckHaveAlreadySameOperationName(operation.OperationName)
               );

            if (result != null)
            {
                return result;
            }
            _operationDAL.Add(operation);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<Operation>> GetAll()
        {
            return new SuccessDataResult<List<Operation>>(_operationDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<Operation> GetByID(int ID)
        {
            return new SuccessDataResult<Operation>(_operationDAL.Get(p => p.OperationID == ID));
        }

        public IDataResult<List<Operation>> GetByProductType(Entities.Concrete.Enums.ProductTypes productType)
        {
            return new SuccessDataResult<List<Operation>>(_operationDAL.GetAll(p => p.ProductTypes == productType));
        }

        public IResult Update(Operation operation)
        {
            _operationDAL.Update(operation);
            return new SuccessResult("Successfully Updated");
        }
    
        //Business Rule Methodları
        private IResult CheckIfHaveAlreadySameProductType(Entities.Concrete.Enums.ProductTypes ProductType)
        {
            if (_operationDAL.GetAll(p => p.ProductTypes == ProductType).Count == 1)
            {
                return new ErrorResult("This Product Type Name already exits!");
            }
            else
            {
                return new SuccessResult();
            }
        }
        private IResult CheckHaveAlreadySameOperationName(string OperationName)
        {
            if (_operationDAL.GetAll(p => p.OperationName == OperationName).Count == 1)
            {
                return new ErrorResult("This Operation Name already exits!");
            }
            else
            {
                return new SuccessResult();
            }
        }
    
    }
}
