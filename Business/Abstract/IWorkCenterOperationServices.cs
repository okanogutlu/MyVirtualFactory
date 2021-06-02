using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkCenterOperationServices
    {
        IDataResult<List<WorkCenterOperation>> GetAll(); //Tüm WorkCenterOperation  getir.
        IDataResult<WorkCenterOperation> GetByWorkCenterOperationID(int ID);//ID ile WorkCenterOperation getir.
        IDataResult<List<WorkCenterOperation>> GetByWorkCenterID(int ID);//ID ile bir makinenin yapabileceği işleri getirir.
        IDataResult<List<WorkCenterOperation>> GetByOperationID(int ID); //Tüm WorkCenterOperation  getir.
        IDataResult<List<WorkCenterOperationsDetailDTO>> GetWorkCenterOperationDetails();
        IDataResult<List<WorkCenterOperationsDetailDTO>> GetWorkCenterOperationDetailsbyWorkCenterName(string workcentername);
         IDataResult<List<WorkCenterOperationsDetailDTO>> GetWorkCenterOperationDetailsByOperationName(string operationName);
        IDataResult<List<WorkCenterOperationsDetailDTO>> GetWorkCenterOperationDetailsByProductType(string ProductType);
        IResult Add(WorkCenterOperation workCenterOperation);
        IResult Update(WorkCenterOperation workCenterOperation);
    }
}
