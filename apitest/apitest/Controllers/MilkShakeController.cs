using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace apitest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilkShakeController : Controller
    {
        public List<string> milkShakes = new() {"StrawBerry","BlueBerry","Raspberry"};


        [HttpGet("GetMilkshakes")]
        public IEnumerable<string> GetFavoriteMilkShake(string milkShake)
        {
            if (!String.IsNullOrEmpty(milkShake))
            {
                var milkshake = milkShakes.Contains(milkShake) ? milkShakes.Where(e => e == milkShake) : null;
                if (milkshake.Count() > 0)
                {
                    CookieOptions co = new CookieOptions() {Expires = DateTimeOffset.Now.AddMinutes(5)};
                    Response.Cookies.Append("favoriteMilkshake",milkShake,co);
                }

                return milkshake;
            }
            else
            {
                return milkShakes;
            }
        }

        [HttpGet("GetMilkshakeCookie")]
        public string GetMilkshakeCookie()
        {
            var temp = Request.Cookies["favoriteMilkshake"];
            return String.IsNullOrEmpty(temp) ? "unknown" : temp;
        }
    }
}
