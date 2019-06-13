using Melidya.MVC.UI.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melidya.MVC.UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> musteriler = new List<Customer>();
            musteriler = HTTPHelper.SendRequest<List<Customer>>("http://localhost:55096/", "Customer/GetCustomers", Method.GET);
            return View(musteriler);
        }
        public ActionResult CustomerDetail(string id)
        {
            //bu metodla yapınca sadece alfkı için görebiliyorduk
            //Customer musteriler = new Customer();
            //musteriler = HTTPHelper.SendRequest<Customer>("http://localhost:55096/", "Customer/CustomerDetail?customerid=ALFKI", Method.GET);
            //return View(musteriler);

            var client = new RestClient("http://localhost:55096/");
            var request = new RestRequest("Customer/CustomerDetail", Method.GET);
            request.AddQueryParameter("customerid", id);

            Customer customer = client.Execute<Customer>(request).Data;
            return View(customer);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            var client = new RestClient("http://localhost:55096/");
            var request = new RestRequest("Customer/AddCustomer", Method.POST);

            request.AddJsonBody(customer);
            client.Execute(request);
            return RedirectToAction("Index");

        }
    }
}