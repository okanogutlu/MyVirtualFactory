using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDAL : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<User> GetAll();
        List<User> GetCustomers();
        void UpdateUserProfile(UpdateUserProfileDto updateUserProfileDTO);
    }
}
