using GithubApiIsrotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GithubApiIsrotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRepositories(SearchModel q)
        {
            if(q == null)
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
                var collections = JsonConvert.DeserializeObject<RepositoriesModels>(rawJSON);

                return View("About", collections.Items);
            }
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Bookmark(int id)
        {
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View();
        }
    }
}