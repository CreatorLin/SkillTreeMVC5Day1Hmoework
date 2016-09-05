using System;
using System.Collections.Generic;

namespace Homework1.Models
{
    public class DbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Configuration.ValidateOnSaveEnabled = false;
            base.Seed(context);
        }
    }
}