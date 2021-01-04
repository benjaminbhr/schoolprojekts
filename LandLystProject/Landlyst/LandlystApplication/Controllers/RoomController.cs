using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using LandlystApplication.Models;
using Newtonsoft.Json;
using WebGrease.Css.Ast.Selectors;

namespace LandlystApplication.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        /// <summary>
        /// Sends a GET request on Rooms to the API with 3 parameters.
        /// </summary>
        /// <param name="CheckIn_Date"></param>
        /// <param name="CheckOut_Date"></param>
        /// <param name="features"></param>
        /// <returns></returns>
        public ActionResult Room(string CheckIn_Date,string CheckOut_Date,string features)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://localhost:44350/api/");
                StringContent queryString = new StringContent($"?CheckIn_Date={CheckIn_Date}&CheckOut_Date={CheckOut_Date}&roomfeatures={features}");
                var response = client.PostAsync("https://localhost:44350/api/Room" + $"?CheckIn_Date={CheckIn_Date}&CheckOut_Date={CheckOut_Date}&roomfeatures={features}", queryString).GetAwaiter().GetResult();
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var rooms = JsonConvert.DeserializeObject<List<Room>>(content);
                rooms = SetTotalCostOfRooms(rooms);
                return PartialView(rooms);
            }
        }


        //Calclulates total cost per night on each room based on roomcost + all the features on that room's cost.
        public int CalculateTotalCostPerNight(Room room)
        {
            int baseCost = room.RoomCost;
            int featuresCost = 0;
            foreach (var item in room.Feature)
            {
                featuresCost += item.FeatureCost;
            }

            return baseCost + featuresCost;
        }

        //Sets the total cost property on each room based on the int returned by method "CalculateTotalCostPerNight".
        public List<Room> SetTotalCostOfRooms(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                room.TotalCost = CalculateTotalCostPerNight(room);
            }

            return rooms;
        }
    }
}