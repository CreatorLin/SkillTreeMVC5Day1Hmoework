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
        private int amounttt;

        public bool AutoSave { get; set; } = false;

        public AccountBookManager(IStore<AccountBook> store)
        {
            this.store = store;
        }

        public AccountBook FindById(Guid id)
        {
            return store.GetSingle(p => p.Id == id);
        }

        public void Add(AccountBook model)
        {
            model.Id = Guid.NewGuid();

            store.Create(model);

            if (AutoSave)
            {
                Save();
            }
        }

        public void Update(AccountBook accountBook)
        {
            var dbData = this.FindById(accountBook.Id);

            dbData.Amounttt = accountBook.Amounttt;
            dbData.Categoryyy = accountBook.Categoryyy;
            dbData.Dateee = accountBook.Dateee;
            dbData.Remarkkk = accountBook.Remarkkk;
        }

        public void SetAmounttt(Guid id, int amounttt)
        {
            this.FindById(id).Amounttt = amounttt;

            if (AutoSave)
            {
                Save();
            }
        }

        public void SetCategoryyyt(Guid id, int categoryyy)
        {
            this.FindById(id).Categoryyy = amounttt;

            if (AutoSave)
            {
                Save();
            }
        }

        public void SetDateee(Guid id, DateTime dateee)
        {
            this.FindById(id).Dateee = dateee;

            if (AutoSave)
            {
                Save();
            }
        }

        public void SetRemarkkk(Guid id, string remarkkk)
        {
            this.FindById(id).Remarkkk = remarkkk;

            if (AutoSave)
            {
                Save();
            }
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