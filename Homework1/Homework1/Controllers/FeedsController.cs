using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class FeedsController : BaseController
    {
        // GET: Feeds
        public ActionResult Index()
        {
            var feed = new SyndicationFeed(
                           "我的記賬本",
                           "記帳本更新紀錄",
                           new Uri(Url.Action("Index", "feeds", null, "http"))
                         );

            feed.Items = AccountBookManager.Lookup().ToList()
                            .Select(p => new SyndicationItem(
                                (p.Categoryyy == 0 ? "收入 $" : "支出 $") + p.Categoryyy,
                                p.Remarkkk,
                                new Uri(Url.Action("Detail", "Money", new { id = p.Id }, "http")))
                             );

            return Rss(feed);
        }
    }

}