using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOperationServices
    {
        IDataResult<List<Operation>> GetAll(); //Tüm operasyonları getir.
        IDataResult<Operation> GetByID(int ID);//ID ile operasyon getir.
        IDataResult<List<Operation>> GetByProductType(Entities.Concrete.Enums.ProductTypes productType);//ürün tipinin üretilmesi için yapılacak işlemleri getir.
        IResult Add(Operation operation);
        IResult Update(Operation operation);
    }
}
