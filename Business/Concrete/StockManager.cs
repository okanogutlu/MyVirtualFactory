using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StockManager : IStockServices
    { //*sadece bir tane productID olmalı *AmountOfStock negatif olmamalı

        IStockDAL _stockDAL;

        public StockManager(IStockDAL stockDAL) => _stockDAL = stockDAL;

        public IResult Add(Stock operation)
        {
            var result = BusinessRules.Run(
              CheckIfSameProductID( operation.ProductID),
              CheckIfAmountValid(operation.AmountOfStock)
               );

            if (result != null)
            {
                return result;
            }
            _stockDAL.Add(operation);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<Stock>> GetAll()
        {
            return new SuccessDataResult<List<Stock>>(_stockDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<Stock> GetByID(int ID)
        {
            return new SuccessDataResult<Stock>(_stockDAL.Get(p => p.StockID == ID));
        }

        public IDataResult<Stock> GetByProductID(int productID)
        {
            return new SuccessDataResult<Stock>(_stockDAL.Get(p => p.ProductID == productID));
        }

        public IResult Update(Stock operation)
        {
            _stockDAL.Update(operation);
            return new SuccessResult("Successfully Updated");
        }

        //Business Rules
        private IResult CheckIfSameProductID(int productID)
        {
            if (_stockDAL.GetAll(p => p.ProductID == productID).Count == 1)
            {
                return new ErrorResult("This Product already exits!");
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckIfAmountValid(int amount)
        {
            if (amount>=0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("Amount should not be less than zero!");
            }
        }

        public IDataResult<List<StockDetailDTO>> GetStockDetails()
        {
            return new SuccessDataResult<List<StockDetailDTO>>(_stockDAL.GetStockDetails());

        }
    }
}
