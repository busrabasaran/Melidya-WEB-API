using Melidya.MVC.UI.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melidya.MVC.UI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            List<Order> sonuc = new List<Order>();
            //TODO HTTP request yap. Gelen JSON stringi List<Order> a çevir.
            //var client = new RestClient("http://localhost:11570/");
            //var request = new RestRequest("order/orders", Method.POST);

            //var response2 = client.Execute<List<Order>>(request);
            //sonuc = response2.Data;

            sonuc = HTTPHelper.SendRequest<List<Order>>("http://localhost:11570/", "order/orders", Method.GET);

            return View(sonuc);
        }
    }
}