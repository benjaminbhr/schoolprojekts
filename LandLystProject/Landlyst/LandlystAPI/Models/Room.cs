using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace LandlystAPI.Models
{
    public class Room
    {
        public int Room_Nr { get; set; }
        public int RoomCost { get; set; }


        public List<Features> Feature { get; set; }
    }
}