using GithubApiIsrotel.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace GithubApiIsrotel.Controllers
{
    [RoutePrefix("api/github")]
    public class GithubAPIController : Controller
    {
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/api/github/search/repositories/{keyword=q}")]
        public ActionResult GetRepositories(string q)
        {
            var url = $"https://api.github.com/search/repositories?q={q}";
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

                //return Json(collections, JsonRequestBehavior.AllowGet);
                return View("Index", collections.Items);
            }
        }

        // GET: GithubAPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GithubAPI/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GithubAPI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GithubAPI/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GithubAPI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GithubAPI/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
