using Homework1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Homework1.Stores
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(DbContext dbContext) : base(dbContext) { }
    }
}