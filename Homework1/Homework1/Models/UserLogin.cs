using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Homework1.Models
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual User User { get; set; }
    }
}