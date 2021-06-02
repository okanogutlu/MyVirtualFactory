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
    public class WorkCenterManager:IWorkCenterServices
    {
        //Active değiştirme özelliği gelsin
        //*workcentername önceden alınmış mı?
        IWorkCenterDAL _workCenterDAL;

        public WorkCenterManager(IWorkCenterDAL workCenterDAL) => _workCenterDAL = workCenterDAL;

        public IResult Add(WorkCenter workCenter)
        {

            var result = BusinessRules.Run(
                CheckIfWorkCenterNameIsSame(workCenter.WorkCenterName)
                );

            if (result != null)
            {
                return result;
            }
            _workCenterDAL.Add(workCenter);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<WorkCenter>> GetAll()
        {
            return new SuccessDataResult<List<WorkCenter>>(_workCenterDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<WorkCenter> GetByID(int ID)
        {
            return new SuccessDataResult<WorkCenter>(_workCenterDAL.Get(p => p.WorkCenterID == ID));
        }

        public IResult Update(WorkCenter workCenter)
        {
            _workCenterDAL.Update(workCenter);
            return new SuccessResult("Successfully Updated");
        }

        public IResult ChangeActiveStatus(WorkCenter workCenter, bool ActiveStatus)
        {
            _workCenterDAL.Get(p => p.WorkCenterID == workCenter.WorkCenterID).Active = ActiveStatus;
            if (ActiveStatus)
            {
                return new SuccessResult("successfully activated");
            }
            else
            {
                return new SuccessResult("Succesfully changed");
            }
        }



        //BusinessRules
        private IResult CheckIfWorkCenterNameIsSame(string Name)
        {
            if (_workCenterDAL.GetAll(p => p.WorkCenterName == Name).Count == 1)
            {
                return new ErrorResult("WorkCenterName  already exists!");
            }
            else
            {
                return new SuccessResult(); 
            }
        }
    }
}
