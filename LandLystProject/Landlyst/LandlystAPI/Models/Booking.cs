using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlystAPI.Models
{
    public class Booking
    {
        public int Room_No { get; set; }
        public DateTime CheckIn_Date { get; set; }
        public DateTime CheckOut_Date { get; set; }
    }
}