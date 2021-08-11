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

        [HttpGet("GetFavoriteSoda")]
        public IEnumerable<string> Get(string sodaKind)
        {
            if (!String.IsNullOrEmpty(sodaKind))
            {
                var sodakind = sodas.Contains(sodaKind) ? sodas.Where(e => e == sodaKind) : null;
                if (sodakind.Count() > 0)
                {
                    CookieOptions co = new CookieOptions() { Expires = DateTimeOffset.Now.AddMinutes(5) };
                    Response.Cookies.Append("favoriteSoda", sodaKind, co);
                }

                return sodakind;
            }
            else
            {
                return sodas;
            }
        }
    }
}
