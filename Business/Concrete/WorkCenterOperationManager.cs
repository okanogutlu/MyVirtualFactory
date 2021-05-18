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
{       //İş türü için birden fazla kayıt var mı? *Birden fazla iş türü için tek bir makina var mı?
        //*WorkCenterID exists mi? *OperationID exits mi?
    public class WorkCenterOperationManager:IWorkCenterOperationServices
    {
        IWorkCenterOperationDAL _workCenterOperationDAL;
        IWorkCenterServices _workCenterServices;
        IOperationServices _operationServices;


        public WorkCenterOperationManager(IWorkCenterOperationDAL workCenterOperationDAL, 
                                            IWorkCenterServices workCenterServices, 
                                            IOperationServices operationServices
                                         )
        {
            _workCenterOperationDAL = workCenterOperationDAL;
            _workCenterServices = workCenterServices;
            _operationServices = operationServices;
        }

        public IResult Add(WorkCenterOperation workCenterOperation)
        {
            var result = BusinessRules.Run(
                CheckIfWorkCenterIDExists(workCenterOperation.WorkCenterID),
                CheckIfOperationIDExists(workCenterOperation.OperationID)
                );

            if (result != null)
            {
                return result;
            }
            _workCenterOperationDAL.Add(workCenterOperation);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<WorkCenterOperation>> GetAll()
        {
            return new SuccessDataResult<List<WorkCenterOperation>>(_workCenterOperationDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<List<WorkCenterOperation>> GetByOperationID(int ID)
        {
            var result = BusinessRules.Run(
               CheckIfOperationIDExists(ID)
               );

            if (result != null)
            {
                return new ErrorDataResult<List<WorkCenterOperation>>("Invalid OperationID!");
            }
            return new SuccessDataResult<List<WorkCenterOperation>>(_workCenterOperationDAL.GetAll(p => p.OperationID == ID),"Successful");
        }

        public IDataResult<List<WorkCenterOperation>> GetByWorkCenterID(int ID)
        {
            var result = BusinessRules.Run(
                CheckIfWorkCenterIDExists(ID)
                );

            if (result != null)
            {
                return new ErrorDataResult<List<WorkCenterOperation>>("Invalid OperationID!");
            }
            return new SuccessDataResult<List<WorkCenterOperation>>(_workCenterOperationDAL.GetAll(p => p.WorkCenterID == ID), "Successful");
        }

        public IDataResult<WorkCenterOperation> GetByWorkCenterOperationID(int ID)
        {
            return new SuccessDataResult<WorkCenterOperation>(_workCenterOperationDAL.Get(p => p.WcOprID == ID));
        }

        public IResult Update(WorkCenterOperation workCenterOperation)
        {
            _workCenterOperationDAL.Update(workCenterOperation);
            return new SuccessResult("Successfully Updated");
        }

        public IDataResult<List<WorkCenterOperationsDetailDTO>> GetWorkCenterOperationDetails()
        {
            return new SuccessDataResult<List<WorkCenterOperationsDetailDTO>>(_workCenterOperationDAL.GetWorkCenterOperationDetails());
        }

        //BusinessRules
        private IResult CheckIfWorkCenterIDExists(int WorkCenterID)
        {
            var doesHave = _workCenterServices.GetByID(WorkCenterID);
            if (doesHave!=null)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("WorkCenterID is invalid!");
            }
        }

        private IResult CheckIfOperationIDExists(int OperationID) 
        {
            var doesHave = _operationServices.GetByID(OperationID);
            if (doesHave != null)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("OperationID is invalid!");
            }
        }

       
    }
}
