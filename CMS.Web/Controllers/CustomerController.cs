using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Domain.ViewModel;
using Newtonsoft.Json;

namespace CMS.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            /*WebClient client = new WebClient();
            client.Headers["Accept"] = "application/json";
            string result = client.DownloadString(new Uri("http://localhost:1920/api/Customer"));
            IList<CustomerViewModel> models = JsonConvert.DeserializeObject<IList<CustomerViewModel>>(result);
            return View(models);*/
            return View();
        }
    }
}