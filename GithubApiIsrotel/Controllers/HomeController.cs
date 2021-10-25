using GithubApiIsrotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GithubApiIsrotel.Controllers
{
    public class HomeController : Controller
    {
        public RepositoriesModels RepositoriesModels { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRepositories(SearchModel q)
        {
            if (q == null)
            {
                RedirectToAction("Index");
            }
            var url = $"https://api.github.com/search/repositories?q={q.KeyWord}";
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("user-agent", "only a test!");
                var rawJSON = string.Empty;
                try
                {
                    rawJSON = webClient.DownloadString(url);
                }
                catch (Exception e)
                {
                    return HttpNotFound(e.ToString());
                }
                RepositoriesModels = JsonConvert.DeserializeObject<RepositoriesModels>(rawJSON);
                TempData["repoModels"] = RepositoriesModels;
                var userItems = new List<UserItems>();

                if (Session["userCardItem"] != null)
                {
                    userItems = ((List<UserItems>)Session["userCardItem"]);
                }


                return View("ResultListView", RepositoriesModels.Items);
            }
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Bookmark(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            var userItems = new List<UserItems>();

            var temp = TempData["repoModels"] as RepositoriesModels;
            var userCardItem = temp.Items.Where(w => w.Id == id).FirstOrDefault();

            if (Session["userCardItem"] != null)
            {
                userItems = ((List<UserItems>)Session["userCardItem"]);
            }
            userItems.Add(userCardItem);
            Session["userCardItem"] = userItems;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteBookMark(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }
            var userItems = new List<UserItems>();

            if (Session["userCardItem"] != null)
            {
                userItems = ((List<UserItems>)Session["userCardItem"]);
            }
            userItems.RemoveAll(w => w.Id == id);
            Session["userCardItem"] = userItems;

            return RedirectToAction("Index", "Home");
        }
    }
}