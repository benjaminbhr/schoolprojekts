using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MovieNight
{
    public static class MovieManager
    {
        public static List<Movie> GetMovies()
        {
            return DalManager.GetMovies();
        }
        public static List<Actor> GetActors()
        {
            return DalManager.GetActors();
        }
        public static List<Movie> SearchMovies(string search)
        {
            return DalManager.SearchMovies(search);
        }
        public static List<Actor> SearchActor(string search)
        {
            return DalManager.SearchActors(search);
        }
        public static List<Movie> SearchGenres(string search)
        {
            return DalManager.SearchGenre(search);
        }
        public static Actor InsertActor(Actor actor)
        {
            return DalManager.InsertActor(actor);
        }
        public static Movie InsertMovie(Movie movie)
        {
            return DalManager.InsertMovie(movie);
        }
        public static Genre InsertGenre(Genre genre)
        {
            return DalManager.InsertGenre(genre);
        }
        public static List<Genre> GetGenres()
        {
            return DalManager.GetGenres();
        }
        public static Movie UpdateMovie(Movie movie,int update)
        {
            return DalManager.UpdateMovie(movie,update);
        }
        public static Actor UpdateActor(Actor actor, int update)
        {
            return DalManager.UpdateActor(actor, update);
        }
        public static Genre UpdateGenre(Genre genre, int update)
        {
            return DalManager.UpdateGenre(genre, update);
        }
        public static string DeleteMovie(Movie movie,string deletemovie)
        {
            return DalManager.DeleteMovie(movie,deletemovie);
        }
        public static string DeleteActor(Actor actor,string deleteactor)
        {
            return DalManager.DeleteActor(actor, deleteactor);
        }
        public static string DeleteGenre(Genre genre, string deletegenre)
        {
            return DalManager.DeleteGenre(genre, deletegenre);
        }
    }
}
