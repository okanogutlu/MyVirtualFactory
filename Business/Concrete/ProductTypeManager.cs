// **ProductType artık enum olduğundan dolayı, bu Class artık kullanılmıyor.

//using Business.Abstract;
//using Core.Utilities.Business;
//using Core.Utilities.Results;
//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Business.Concrete
//{
//    public class ProductTypeManager : IProductTypeServices
//    {
//        IProductTypeDAL _productTypeDAL;

//        public ProductTypeManager(IProductTypeDAL productTypeDAL) => _productTypeDAL = productTypeDAL;

//        public IResult Add(ProductType productType)
//        {
//            var result = BusinessRules.Run(
//                CheckIfHaveAlreadySameOperationTypeName(productType.ProductTypeName)
//                );

//            if (result != null)
//            {
//                return result;
//            }
//            _productTypeDAL.Add(productType);
//            return new SuccessResult("Successfully Added");
//        }

//        public IDataResult<List<ProductType>> GetAll()
//        {
//            return new SuccessDataResult<List<ProductType>>(_productTypeDAL.GetAll(), "Successfully Listed");

//        }

//        public IDataResult<ProductType> GetByID(int ID)
//        {
//            return new SuccessDataResult<ProductType>(_productTypeDAL.Get(p => p.ProductTypeID == ID));
//        }

//        public IDataResult<ProductType> GetByProductTypeName(string ProductTypeName)
//        {
//            var result = BusinessRules.Run(
//                CheckIfProductTypeNameExists(ProductTypeName)
//                );

//            if (result != null)
//            {
//                return new ErrorDataResult<ProductType>(result.Message);
//            }
//            else
//            {
//                return new SuccessDataResult<ProductType>(_productTypeDAL.Get(p => p.ProductTypeName == ProductTypeName));
//            }
//        }

//        public IResult Update(ProductType productType)
//        {
//            _productTypeDAL.Update(productType);
//            return new SuccessResult("Successfully Updated");
//        }

//        //Business Rules
//        private IResult CheckIfHaveAlreadySameOperationTypeName(string ProductTypeName)
//        {
//            if (_productTypeDAL.GetAll(p => p.ProductTypeName == ProductTypeName).Count == 1)
//            {
//                return new ErrorResult("This Product Type Name already exits!");
//            }
//            else
//            {
//                return new SuccessResult();
//            }
//        }

//        private IResult CheckIfProductTypeNameExists(string productTypeName)
//        {
//            if (_productTypeDAL.GetAll(p => p.ProductTypeName == productTypeName).Count == 1)
//            {
//                return new SuccessResult();
//            }
//            else
//            {
//                 return new ErrorResult("Invalid ProductTypeName!");
//            }
//        }
//    }
//}
