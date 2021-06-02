using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISubProductTreeServices
    {
        IDataResult<List<SubProductTree>> GetAll(); //Tüm SubProductTreeleri  getir.
        IDataResult<SubProductTree> GetBySubProductID(int ID);//ID ile SubProductTree getir.
        IDataResult<List<SubProductTree>> GetAllByProductID(int ID);//ProductID ile SubProductTreeleri getir.
        IDataResult<List<SubProductTreeDetailDTO>> GetSubProductTreeDetails();
        IDataResult<List<SubProductTreeDetailDTO>> GetSubProductTreeDetailsByID(int ID);
        IDataResult<List<SubProductTreeDetailDTO>> GetSubProductTreeDetailsByProductName(string Name);
        IDataResult<int> GetAmount(int SubProductID, int ProductID);
        IResult Add(SubProductTree subProductTree);
        IResult Update(SubProductTree subProductTree);
    }
}
