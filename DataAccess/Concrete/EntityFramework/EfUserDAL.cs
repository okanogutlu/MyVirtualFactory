using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDAL : EfEntityRepositoryBase<User, MSSQLDbContext>, IUserDAL
    {
        public List<User> GetAll()
        {
            using (var context = new MSSQLDbContext())
            {
                var result = from users in context.Users
                             select new User { ID = users.ID, FirstName = users.FirstName, Email = users.Email };
                return result.ToList();

            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MSSQLDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.ID equals userOperationClaim.OperationClaim
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };
                return result.ToList();

            }
        }

            public List<User> GetCustomers()
        {
            using (var context = new MSSQLDbContext())
            {
                var result = from users in context.Users
                             join userOperationClaim in context.UserOperationClaims //Burada bir problem çıkabilir
                                 on users.ID equals userOperationClaim.UserID
                             where userOperationClaim.OperationClaim == 2
                             select new User
                             {
                                 ID = users.ID,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                             };
                return result.ToList();

            }
        }

        public void UpdateUserProfile(UpdateUserProfileDto updateUserProfileDTO)
        {
            using (var context = new MSSQLDbContext())
            {
                context.Users.FirstOrDefault(u => u.ID == updateUserProfileDTO.userID).FirstName = updateUserProfileDTO.firstName;
                context.Users.FirstOrDefault(u => u.ID == updateUserProfileDTO.userID).Email = updateUserProfileDTO.email;
                context.Users.FirstOrDefault(u => u.ID == updateUserProfileDTO.userID).LastName = updateUserProfileDTO.lastName;
                context.SaveChanges();

            }
        }
    }
}
