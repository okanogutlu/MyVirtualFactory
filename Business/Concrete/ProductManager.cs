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
    //*Productname unique olmalı *productType unique olmalı *ProductType var mı
    //Satılabilir ürünleri getirmeyi ekle!

    public class ProductManager:IProductServices
    {
        IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(
               CheckIfHaveAlreadySameProductName(product.ProductName),
               CheckIfHaveAlreadySameProductType(product.ProductType)
               );

            if (result != null)
            {
                return result;
            }
            _productDAL.Add(product);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(), "Successfully Listed");

        }

        public IDataResult<Product> GetByID(int ID)
        {
            return new SuccessDataResult<Product>(_productDAL.Get(p => p.ProductID == ID));

        }

        public IDataResult<Product> GetByProductName(string name)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(name));
            if (result != null)
            {
                return new ErrorDataResult<Product>(result.Message);
            }
            return new SuccessDataResult<Product>(_productDAL.Get(p=>p.ProductName==name),"Successfully Found");
        }

        public IDataResult<List<Product>> GetByProductType(Entities.Concrete.Enums.ProductTypes productType)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.ProductType == productType));
        }

        public IDataResult<List<Product>> GetSalableProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p=>p.IsSalable==true), "Successfully Listed");
        }

        public IResult Update(Product productItem)
        {
            _productDAL.Update(productItem);
            return new SuccessResult("Successfully Updated");
        }
        //Business Rules

        private IResult CheckIfHaveAlreadySameProductName(string productName)
        {
            if (_productDAL.GetAll(p => p.ProductName == productName).Count == 1)
            {
                return new ErrorResult("This Product Name already exits!");
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckIfHaveAlreadySameProductType(Entities.Concrete.Enums.ProductTypes productType)
        {
            if (_productDAL.GetAll(p => p.ProductType == productType).Count == 1)
            {
                return new ErrorResult("This Product Name already exits!");
            }
            else
            {
                return new SuccessResult();
            }
        } //ProductType tablosu eklenirse aktive edilmelidir.

        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDAL.GetAll(p => p.ProductName == productName).Count == 1)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("ProductName is Invalid!");
            }
        }
    }
}
