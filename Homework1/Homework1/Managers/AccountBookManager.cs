using Homework1.Models;
using Homework1.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework1.Managers
{
    public class AccountBookManager
    {
        private IStore<AccountBook> store;

        public AccountBookManager(IStore<AccountBook> store)
        {
            this.store = store;
        }

        public IQueryable<AccountBook> Lookup()
        {
            return store.LookupAll();
        }

        public void Save()
        {
            store.Save();
        }
    }
}