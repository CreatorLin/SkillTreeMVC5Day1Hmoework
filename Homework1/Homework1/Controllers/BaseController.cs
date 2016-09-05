using Homework1.Managers;
using Homework1.Models;
using Homework1.Stores;
using System.ServiceModel.Syndication;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class BaseController : Controller
    {
        protected MyDbContext dbContext;
        protected AccountBookManager _accountBookManager;
        protected AccountBookManager AccountBookManager {
            get {
                if(_accountBookManager == null)
                {
                    _accountBookManager = new AccountBookManager(new Store<AccountBook>(dbContext));
                }

                return _accountBookManager;
            }
        }

        public BaseController()
        {
            dbContext = new MyDbContext();
        }

        public RssResult Rss(SyndicationFeed feed)
        {
            return new RssResult(feed);
        }
    }
}