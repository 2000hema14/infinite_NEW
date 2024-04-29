using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Assessment1.Models;

namespace Mvc_Assessment1.Controllers
{
    public class CodeController : Controller
    {
        private northwinddbEntities db = new northwinddbEntities();

        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomersInGermany()
        {
            var customersInGermany = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customersInGermany);
        }

        public ActionResult CustomerWithOrderId10248()
        {
            var customer = db.Customers.FirstOrDefault(c => c.Orders.Any(o => o.OrderID == 10248));
            return View(customer);
        }
    }
}