using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISubProductTreeDAL:IEntityRepository<SubProductTree>
    {
         List<SubProductTreeDetailDTO> GetSubProductTreeDetails();
         List<SubProductTreeDetailDTO> GetSubProductTreeDetailsByProductName(string Name);
         List<SubProductTreeDetailDTO> GetSubProductTreeDetailsByID(int ID);
        
    }
}
