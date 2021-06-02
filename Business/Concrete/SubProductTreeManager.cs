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
    public class SubProductTreeManager:ISubProductTreeServices
    {
        //*Product ID valid Mi? *SubProductID valid mi?
        //Verilen productID'ye göre SubProduct'ları getir
        //SubProductID ve ProductID ye göre gereken amount u getir
        ISubProductTreeDAL _subProductTreeDAL;
        IProductServices _productServices;

        public SubProductTreeManager(ISubProductTreeDAL subProductTreeDAL, IProductServices productServices)
        {
            _subProductTreeDAL = subProductTreeDAL;
            _productServices = productServices;
        }

        public IResult Add(SubProductTree subProductTree)
        {
            var result = BusinessRules.Run(
               CheckIfProductIDIsValid(subProductTree.ProductID),
               CheckIfProductIDIsValid(subProductTree.SubProductID)
               );

            if (result != null)
            {
                return result;
            }
            _subProductTreeDAL.Add(subProductTree);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<SubProductTree>> GetAll()
        {
            return new SuccessDataResult<List<SubProductTree>>(_subProductTreeDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<List<SubProductTree>> GetAllByProductID(int ID)
        {
            var result = BusinessRules.Run(
              CheckIfProductIDIsValid(ID)
              );
            if (result != null)
            {
                return new ErrorDataResult<List<SubProductTree>>("Invalid ID!");
            }
            return new SuccessDataResult<List<SubProductTree>>(_subProductTreeDAL.GetAll(p => p.ProductID == ID));
        }

        public IDataResult<SubProductTree> GetBySubProductID(int ID)
        {
            var result = BusinessRules.Run(
               CheckIfProductIDIsValid(ID)
               );

            if (result != null)
            {
                return new ErrorDataResult<SubProductTree>("Invalid ID!");
            }
            return new SuccessDataResult<SubProductTree>(_subProductTreeDAL.Get(p => p.SubProductID == ID));
        }

        public IResult Update(SubProductTree subProductTree)
        {
            _subProductTreeDAL.Update(subProductTree);
            return new SuccessResult("Successfully Updated");
        }

        public IDataResult<int> GetAmount(int SubProductID,int ProductID)
        {
            var result = BusinessRules.Run(
              CheckIfProductIDIsValid(ProductID),
              CheckIfProductIDIsValid(SubProductID)
              );

            if (result != null)
            {
                return new ErrorDataResult<int>("Invalid SubProductID or ProductID!");
            }
            return new SuccessDataResult<int>(_subProductTreeDAL.Get(p => p.ProductID == ProductID && p.SubProductID == SubProductID).Amount);
        }
        
        public IDataResult<List<SubProductTreeDetailDTO>> GetSubProductTreeDetails()
        {
            return new SuccessDataResult<List<SubProductTreeDetailDTO>>(_subProductTreeDAL.GetSubProductTreeDetails());

        }

        public IDataResult<List<SubProductTreeDetailDTO>> GetSubProductTreeDetailsByID(int ID)
        {
            return new SuccessDataResult<List<SubProductTreeDetailDTO>>(_subProductTreeDAL.GetSubProductTreeDetails());

        }

        public IDataResult<List<SubProductTreeDetailDTO>> GetSubProductTreeDetailsByProductName(string Name)
        {
            return new SuccessDataResult<List<SubProductTreeDetailDTO>>(_subProductTreeDAL.GetSubProductTreeDetailsByProductName(Name));

        }

        //BusinessRules
        private IResult CheckIfProductIDIsValid(int ID)
        {
            if (_productServices.GetByID(ID).Success)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

       
    }
}
