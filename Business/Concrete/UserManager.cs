using Business.Abstract;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserServices
    {
        IUserDAL _userDal;
        IOrderServices _orderServices;
        

        public UserManager(IUserDAL userDal,IOrderServices OrderServices)
        {
            _userDal = userDal;
            _orderServices = OrderServices;
        }

        public IDataResult<List<OperationClaim>> GetClaimsForApi(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Successfully Added");
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Successfully Updated!");
        }

        public IDataResult<User> GetByMailForApi(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OrderDetailDTO>> GetOrders(User user)
        {
            return _orderServices.GetOrderDetailsByCustomerID(user.ID);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<User>> GetCustomers()
        {
            return new SuccessDataResult<List<User>>( _userDal.GetCustomers());
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(u => u.Email == userName);
        }

        public IResult UpdateUserProfile(UpdateUserProfileDto updateUserProfileDto)
        {
            _userDal.UpdateUserProfile(updateUserProfileDto);
            return new SuccessResult();
        }
    }
}
