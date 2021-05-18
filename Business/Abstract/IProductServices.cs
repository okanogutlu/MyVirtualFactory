using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductServices
    {
        IDataResult<List<Product>> GetAll(); //Tüm Productları  getir.
        IDataResult<Product> GetByID(int ID);//ID ile product getir.
        IDataResult<Product> GetByProductName(string name);//ProductName ile product getir.
        IDataResult <List<Product>> GetByProductType(Entities.Concrete.Enums.ProductTypes productType);//Producttype ile product getir.
        IResult Add(Product product);
        IResult Update(Product product);
    }
}
