using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace apitest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftDrinkController : Controller
    {
        /// <summary>
        /// Gets the value from the favoriteSoda cookie from Request.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFavoriteSoftDrink")]
        public string GetFavoriteSoftDrink()
        {
            string cookieValue = Request.Cookies["favoriteSoda"];

            return String.IsNullOrEmpty(cookieValue) ? "No cookie found" : cookieValue;
        }
    }
}
