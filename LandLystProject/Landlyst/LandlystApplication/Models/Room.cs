using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlystApplication.Models
{
    public class Room
    {
        public int Room_Nr { get; set; }
        public int RoomCost { get; set; }
        public int TotalCost { get; set; }
        public List<Features> Feature { get; set; }

    }
}