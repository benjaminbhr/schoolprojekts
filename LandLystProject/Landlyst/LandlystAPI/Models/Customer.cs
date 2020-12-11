using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace LandlystAPI.Models
{
    public class Customer
    {
        public int Phone_Nr { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostalCode { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }

        public Booking booking { get; set; }
    }
}