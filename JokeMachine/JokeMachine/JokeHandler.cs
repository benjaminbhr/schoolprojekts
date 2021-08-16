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
        public List<Joke> GetJokes(EJokeLang lang, EJokeCategory cat, bool authorized)
        {
            if (authorized)
            {
                switch (cat)
                {
                    case EJokeCategory.Dadjokes:
                        return GetDadJokes(lang);
                    case EJokeCategory.Darkjokes:
                        return GetDarkJokes(lang);
                    default:
                        break;
                }
            }
            else
            {
                switch (cat)
                {
                    case EJokeCategory.Dadjokes:
                        return GetDadJokes(lang);
                    default:
                        break;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets dad jokes based on language specified
        /// </summary>
        /// <param name="lang"></param>
        /// <returns>List of jokes</returns>
        public List<Joke> GetDadJokes(EJokeLang lang)
        {
            switch (lang)
            {
                case EJokeLang.Danish:
                    return dal.dadJokesDanish;
                case EJokeLang.English:
                    return dal.dadJokesEnglish;
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// Gets dark jokes based on language specified
        /// </summary>
        /// <param name="lang"></param>
        /// <returns>List of Jokes</returns>
        public List<Joke> GetDarkJokes(EJokeLang lang)
        {
            switch (lang)
            {
                case EJokeLang.Danish:
                    return dal.darkJokesDanish;
                case EJokeLang.English:
                    return dal.darkJokesEnglish;
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// Gets a random joke
        /// </summary>
        /// <param name="alrdyRecievedJokes">Jokes already recieved in current session</param>
        /// <param name="jokeCategory">What category the joke should be from</param>
        /// <param name="jokeLang">What language the joke should be in</param>
        /// <param name="authorized">Is the request authorized for the desired joke category</param>
        /// <returns> A joke </returns>
        public Joke GetRandomJoke(List<Joke> alrdyRecievedJokes,EJokeCategory jokeCategory,EJokeLang jokeLang,bool authorized)
        {
            //Gets jokes based on Language,Category and authorization
            var jokes = GetJokes(jokeLang,jokeCategory, authorized);

            //Checks if jokes is null
            if (jokes != null)
            {
                var excludedIDs = new HashSet<int>(alrdyRecievedJokes.Select(e => e.Id));
                List<Joke> result = jokes.Where(e => !excludedIDs.Contains(e.Id)).ToList();
                Joke rndJoke = result.Any() ? result.ElementAt(RandomJokeNumber(result.Count)) : null;
                return rndJoke;
            }

            return null;
        }

        public int RandomJokeNumber(int listLength)
        {
            var random = new Random();
            var rnd = random.Next(0, listLength);
            return rnd;
        }

        public EJokeCategory GetJokeCategory(string categoryString)
        {
            var jokeEnum = categoryString != null ? Enum.Parse(typeof(EJokeCategory), categoryString) : EJokeCategory.Dadjokes;
            return (EJokeCategory)jokeEnum;
        }

        public EJokeLang GetLanguageFromHeader(string langString)
        {
            if (langString.Contains("en"))
            {
                return EJokeLang.English;
            }
            else if (langString.Contains("dk"))
            {
                return EJokeLang.Danish;
            }
            else
            {
                return EJokeLang.English;
            }
        }


    }
}
