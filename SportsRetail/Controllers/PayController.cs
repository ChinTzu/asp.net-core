using Microsoft.AspNetCore.Mvc;
using SportsRetail.Data.Models;
using SportsRetail.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Controllers
{
    public class PayController : Controller
    {
        // GET: Cart/Create
        public ActionResult Create(decimal totalPrice)
        {
            ViewBag.totalPrice = totalPrice;
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(Pay pay)
        {
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_vqtwGU271Ml4ScydIJWVoCzs00FnajUr49";

            //create customer
            var customerOptions = new CustomerCreateOptions
            {
                Description = pay.CardName,
                Source = pay.StripeToken,
                Email = pay.Email,
                Metadata = new Dictionary<string, string>()
                {
                    {"Phone Number",  pay.Phone }
                }
            };
            var customerService = new CustomerService();
            Customer customer = customerService.Create(customerOptions);

            long totalPrice = (long)Math.Truncate(decimal.Parse(Request.Form["totalPrice"]) * 100m);

            var createOptions = new ChargeCreateOptions
            {
                Amount = totalPrice,
                Currency = "myr",
                Customer = customer.Id
            };

            var service = new ChargeService();
            Charge charge = service.Create(createOptions);

            var model = new ChargeViewModel();
            model.ChargeId = charge.Id;
            model.CustomerId = charge.CustomerId;

            return View("OrderStatus", model);
        }
    }
}
