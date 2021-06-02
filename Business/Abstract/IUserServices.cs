using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserServices 
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsForApi(User user);
        IResult Add(User user);
        IResult Update(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetCustomers();
        IDataResult<User> GetByMailForApi(string email);
        IDataResult<List<OrderDetailDTO>> GetOrders(User user);
        User GetByUserName(string userName);
        IResult UpdateUserProfile(UpdateUserProfileDto updateUserProfileDto);
    }
}
