using Homework1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Homework1.Stores
{
    public class UserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(DbContext dbContext) : base(dbContext) { }

        public override Task CreateAsync(User user)
        {
            user.Id = Guid.NewGuid();

            return base.CreateAsync(user);
        }
    }
}