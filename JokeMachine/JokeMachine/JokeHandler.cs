using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JokeMachine
{
    public class JokeHandler
    {
        private DAL dal = new DAL();
        public List<Joke> JokeListBasedOnCategory(EJokeCategory jokeCategory)
        {
            switch (jokeCategory)
            {
                case EJokeCategory.Dadjokes: return dal.dadJokes;
            }
            return null;
        }

        public Joke GetRandomJoke(List<Joke> alrdyRecievedJokes,EJokeCategory jokeCategory,string jokeLang)
        {
            var tempList = JokeListBasedOnCategory(jokeCategory);
            var cleanedList = tempList.Intersect(alrdyRecievedJokes).ToList();

            var rndJoke = cleanedList.ElementAt(RandomJokeNumber(cleanedList.Count));

            return rndJoke;
        }

        public int RandomJokeNumber(int listLength)
        {
            var random = new Random();
            var rnd = random.Next(0, listLength);
            return rnd;
        }


    }
}
