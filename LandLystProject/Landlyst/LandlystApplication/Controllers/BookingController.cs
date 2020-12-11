using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LandlystApplication.Models;

namespace LandlystApplication.Controllers
{
    public class BookingController : Controller
    {
        public ActionResult Booking()
        {
            return View();
        }

        /// <summary>
        /// Serializes a Customer object and sends it as a POST to the API.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Booking(Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    //HTTP POST
                    var response = client.PostAsync("https://localhost:44350/api/Customer", new StringContent(
                        new JavaScriptSerializer().Serialize(customer), Encoding.UTF8, "application/json")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(customer);
        }
    }
}