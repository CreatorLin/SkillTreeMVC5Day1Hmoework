using Homework1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework1.Managers
{
    public class AccountBookManager
    {
        private MyEntity db;

        public AccountBookManager(MyEntity dbContext)
        {
            db = dbContext;
        }

        public IQueryable<AccountBook> Lookup()
        {
            return db.AccountBooks;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}