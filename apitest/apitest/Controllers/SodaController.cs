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
    public class SodaController : Controller
    {
        public List<string> sodas = new() { "Cola", "Faxe", "MtnDew" };

        /// <summary>
        /// Gets the desired soda if it exists, if it does not exist, returns all possible sodas.
        /// if no sodaKind is specified, returns all possible sodas.
        /// </summary>
        /// <param name="sodaKind">Kind of soda</param>
        /// <returns>IEnumerable list of sodas (string)</returns>
        [HttpGet("GetFavoriteSoda")]
        public IEnumerable<string> Get(string sodaKind)
        {
            if (!String.IsNullOrEmpty(sodaKind))
            {
                var sodakind = sodas.Contains(sodaKind) ? sodas.Where(e => e == sodaKind) : null;
                if (sodakind != null && sodakind.Any())
                {
                    CookieOptions co = new CookieOptions() { Expires = DateTimeOffset.Now.AddMinutes(5) };
                    Response.Cookies.Append("favoriteSoda", sodaKind, co);
                    return sodakind;
                }

                return sodas;
            }
            else
            {
                return sodas;
            }
        }
    }
}
