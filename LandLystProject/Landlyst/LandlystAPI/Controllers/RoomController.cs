using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using LandlystAPI.Models;
using System.Configuration;

namespace LandlystAPI.Controllers
{
    public class RoomController : ApiController
    {
        /// <summary>
        /// This endpoint takes 3 parameters that it then uses to specify to the database what we want returned.
        /// </summary>
        /// <param name="CheckIn_Date">To check if a room is reserved in this period</param>
        /// <param name="CheckOut_Date">To check if a room is reserved in this period</param>
        /// <param name="roomfeatures">To only get rooms with these features.</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetAvailableRooms(string CheckIn_Date,string CheckOut_Date,[FromUri] string roomfeatures)
        {
            string sql = $@"USE Landlyst
                            DECLARE @RoomFeatureResult TABLE (Room_Nr int)
                            DECLARE @Room_NrResult TABLE (Room_Nr int,RoomCost int,RoomFeature varchar(100),FeatureCost int)

                            INSERT INTO @Room_NrResult
                            SELECT Room.Room_No,Room.Cost,Features.Feature,Features.Cost
                            FROM Room INNER JOIN Room_Features rf 
                            ON rf.Room_No = Room.Room_No INNER JOIN Features 
                            ON rf.Feature_ID = Features.Feature_ID 
                            WHERE Room.Room_No 
                            NOT IN(SELECT Booking.Room_No FROM Booking WHERE CheckIn_Date <= '{CheckIn_Date}' AND CheckOut_Date >= '{CheckOut_Date}')

                            {PrepareSQLStatement(roomfeatures)}

                            SELECT Room_Nr,r.Cost AS RoomCost,fe.Feature,fe.Cost AS FeatureCost 
                            FROM @RoomFeatureResult 
                            INNER JOIN Room r 
                            ON r.Room_No = Room_Nr 
                            INNER JOIN Room_Features rf 
                            ON rf.Room_No = Room_Nr 
                            INNER JOIN Features fe 
                            ON fe.Feature_ID = rf.Feature_ID";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LandlystDB"].ConnectionString))
            {
                var orderDictionary = new Dictionary<int, Room>();
                var rooms = connection.Query<Room, Features, Room>(sql, (room, features) =>
                {
                    Room Room;
                    if (!orderDictionary.TryGetValue(room.Room_Nr, out Room))
                    {
                        Room = room;
                        Room.Feature = new List<Features>();
                        orderDictionary.Add(Room.Room_Nr, Room);
                    }

                    Room.Feature.Add(features);
                    return Room;
                },
                        splitOn:"Feature")
                        .Distinct()
                        .ToList();
                return Ok(rooms);
            }
        }


        /// <summary>
        /// This method takes an array of features, and prepares an SQL statement based on those.
        /// It does this by doing a SELECT on each feature in the provided array, and puts an "INTERSECT" in between.
        /// However if it's the last feature in the array, it will not put an "INTERSECT" at the end since this would cause syntax error.
        /// </summary>
        /// <param name="features"></param>
        /// <returns></returns>
        private string PrepareSQLStatement(string features)
        {
            string[] featureArray = SplitStringIntoArrayBasedOnSeperator(features, ',');

            string sql = "INSERT INTO @RoomFeatureResult ";
            for (int i = 0; i < featureArray.Length; i++)
            {
                if (i == featureArray.Length - 1)
                {
                    sql += $@"SELECT Room_Nr FROM @Room_NrResult WHERE RoomFeature = '{featureArray[i]}'";
                }
                else
                {
                    sql += $@"SELECT Room_Nr FROM @Room_NrResult WHERE RoomFeature = '{featureArray[i]}' INTERSECT ";
                }
            }

            return sql;
        }

        /// <summary>
        /// This method takes a string containing values seperated by a seperator,
        /// and then splits that list into an array based on the seperator used/provided
        /// </summary>
        /// <param name="seperatedString">string containing values seperated by a seperator</param>
        /// <param name="seperator">Seperator to split on</param>
        /// <returns></returns>
        private string[] SplitStringIntoArrayBasedOnSeperator(string seperatedString,char seperator)
        {
            string[] stringArray = seperatedString.Split(seperator);
            stringArray = stringArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            return stringArray;
        }
    }
}
