using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Homework1.Models
{
    public class Role : IdentityRole<Guid, UserRole>
    {
        public Role() { }
    }
}