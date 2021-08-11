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
    public class CookiesController : Controller
    {
        private List<string> cookies = new List<string>() {"favoriteSoda", "favoriteMilkshake"};

        [HttpGet("RemoveAllCookies")]
        public string GetRemoveMyCookies()
        {
            var similarCookies = Request.Cookies.Keys.Where(e => cookies.Contains(e));
            if (similarCookies.Any())
            {
                string removedCookies = "These Cookies have been removed: ";
                foreach (var similarCookie in similarCookies)
                {
                    Response.Cookies.Delete(similarCookie);
                    Response.Cookies.Append(similarCookie, String.Empty, new CookieOptions() { Expires = DateTimeOffset.Now.AddDays(-1) });
                    removedCookies += similarCookie + ",";
                }

                return removedCookies;
            }

            return "No Cookies related to this application were found/removed";
        }
    }
}
