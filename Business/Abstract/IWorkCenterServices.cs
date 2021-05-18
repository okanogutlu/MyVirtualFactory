using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkCenterServices
    {
        IDataResult<List<WorkCenter>> GetAll(); //Tüm WorkCenter  getir.
        IDataResult<WorkCenter> GetByID(int ID);//ID ile WorkCenter getir.
        IResult ChangeActiveStatus(WorkCenter workCenter, bool ActiveStatus);
        IResult Add(WorkCenter workCenter);
        IResult Update(WorkCenter workCenter);
    }
}
