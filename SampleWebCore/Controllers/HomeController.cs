using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleWebCore.Models;
using SampleWebCore.Helpers;

namespace SampleWebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Accounts()
        {
            //get token
            string accessTokenApi = configuration.GetSection("SalesForceSettings").GetSection("GetAccessToken").Value;
            var response = WebRequestHelper.Post(accessTokenApi, "");
            var token = JsonHelper.ConvertSalesForceToken(response);

            //get user details
            string accountDataApi = configuration.GetSection("SalesForceSettings").GetSection("GetAccountData").Value;
            Dictionary<string, string> customeHeaders = new Dictionary<string, string>();
            customeHeaders.Add("Authorization", "OAuth " + token.access_token);
            response = WebRequestHelper.Get(accountDataApi, customeHeaders);
            var accounts = JsonHelper.ConvertSalesForceUserList(response);
            return View(accounts);
        }
    }
}
