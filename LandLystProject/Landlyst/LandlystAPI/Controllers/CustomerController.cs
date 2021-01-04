using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using LandlystAPI.Models;

namespace LandlystAPI.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpPost]
        public IHttpActionResult create(Customer customer)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["LandlystDB"].ConnectionString))
            {
                cnn.Open();
                var values = new
                {
                    Phone_Nr = customer.Phone_Nr,
                    Email = customer.Email, 
                    FirstName = customer.FirstName,
                    LastName = customer.LastName, 
                    PostalCode = customer.PostalCode,
                    StreetName = customer.StreetName,
                    HouseNumber = customer.HouseNumber,
                    Room_No = customer.booking.Room_No,
                    CheckIn_Date = customer.booking.CheckIn_Date,
                    CheckOut_Date = customer.booking.CheckOut_Date
                };
                cnn.Query("CreateCustomerAndBooking", values, commandType: CommandType.StoredProcedure);
            }

            return Ok(customer);
        }
    }
}