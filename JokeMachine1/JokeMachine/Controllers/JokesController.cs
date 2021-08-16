using Microsoft.AspNetCore.Mvc;
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
        private JokeHandler jokeHandler = new JokeHandler();
        [HttpGet]
        public Joke Get()
        {
            var recievedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("Jokes");

            if (recievedJokes != null)
            {
                var joke = jokeHandler.GetRandomJoke(recievedJokes, EJokeCategory.Dadjokes, "Danish");
                recievedJokes.Add(joke);
                HttpContext.Session.SetObjectAsJson("Jokes",recievedJokes);
                return joke;
            }
            else
            {
                var joke = jokeHandler.GetRandomJoke(new List<Joke>(), EJokeCategory.Dadjokes, "Danish");
                List<Joke> tempList = new List<Joke>();
                tempList.Add(joke);
                HttpContext.Session.SetObjectAsJson("Jokes",tempList);

                return joke;
            }
        }
    }
}
