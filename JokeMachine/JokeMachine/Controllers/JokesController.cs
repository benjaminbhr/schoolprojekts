using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeMachine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokesController : Controller
    {
        private readonly IConfiguration _configuration;
        private JokeHandler jokeHandler = new JokeHandler();
        [HttpGet("GetJoke")]
        public Joke Get(string category,string language)
        {
            Authorization Auth = new Authorization(_configuration);
            bool isauth = Auth.IsAuthorized(HttpContext.Request.Headers["Api-Key"]);

            List<Joke> recievedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("Jokes");
            EJokeLang lang = language != null ? jokeHandler.GetLanguageFromHeader(language) : jokeHandler.GetLanguageFromHeader(HttpContext.Request.Headers["Accept-Language"].ToString());
            EJokeCategory cat = category != null ? jokeHandler.GetJokeCategory(category) : jokeHandler.GetJokeCategory(HttpContext.Request.Cookies["JokeCategory"]);

            HttpContext.Response.Cookies.Append("JokeCategory", cat.ToString());

            if (recievedJokes != null && recievedJokes.Where(e => e.Id == 100).ToList().Any())
            {
                return new Joke() { Setup = "All jokes has been recieved!" };
            }
            if (recievedJokes != null)
            {
                Joke joke = jokeHandler.GetRandomJoke(recievedJokes, cat, lang, isauth);
                if (joke != null)
                {
                    recievedJokes.Add(joke);
                    HttpContext.Session.SetObjectAsJson("Jokes", recievedJokes);
                    return joke;
                }
                return joke;
            }
            else
            {
                Joke joke = jokeHandler.GetRandomJoke(new List<Joke>(), cat, lang, isauth);
                if (joke != null)
                {
                    List<Joke> jokeList = new List<Joke>();
                    jokeList.Add(joke);
                    HttpContext.Session.SetObjectAsJson("Jokes", jokeList);
                }

                return joke;
            }
        }

        [HttpGet("GetJokeCategorys")]
        public List<string> GetJokeCategorys()
        {
            List<string> categorys = new List<string>();
            Array values = Enum.GetValues(typeof(EJokeCategory));
            foreach (var item in values)
            {
                categorys.Add(item.ToString());
            }
            return categorys;
        }

        public JokesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
