using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MovieNight
{
    public static class DalManager
    {
        private static string cs = @"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=MovieDB;Integrated Security=True";

        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select MovieID, Title, Description,Release_date from Movies", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MovieID"];
                    string title = (string)rdr["Title"];
                    string description = (string)rdr["Description"];
                    string date = (string)rdr["Release_date"];
                    Movie movie = new Movie(id,title, description, date);
                    movies.Add(movie);
                }
                return movies;
            }
        }
        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select ActorID, FirstName, LastName from Actors", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ActorID"];
                    string firstname = (string)rdr["FirstName"];
                    string lastname = (string)rdr["LastName"];
                    Actor actor = new Actor(id, firstname, lastname);
                    actors.Add(actor);
                }
                return actors;
            }
        }
        public static List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select GenreName from GenreType", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string genrename = (string)rdr["GenreName"];
                    Genre genre = new Genre(genrename);
                    genres.Add(genre);
                }
                return genres;
            }
        }
        public static List<Movie> SearchMovies(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select MovieID, Title, Description, Release_date from Movies where title like @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%"+search+"%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MovieID"];
                    string title = (string)rdr["Title"];
                    string description = (string)rdr["Description"];
                    string date = (string)rdr["Release_date"];
                    Movie movie = new Movie(id,title, description,date);
                    movies.Add(movie);
                }
                return movies;
            }
        }
        public static List<Actor> SearchActors(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select ActorID, FirstName, LastName from Actors where Firstname like @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ActorID"];
                    string firstname = (string)rdr["FirstName"];
                    string lastname = (string)rdr["LastName"];
                    Actor actor = new Actor(id, firstname, lastname);
                    actors.Add(actor);
                }
                return actors;
            }
        }
        public static List<Movie> SearchGenre(string search)
        {
            List<Movie> genres = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Movies.MovieID,Title,Description,Release_date FROM Movies INNER JOIN Genre ON Movies.MovieID = Genre.MovieID INNER JOIN GenreType ON GenreType.GenreID = Genre.GenreID WHERE GenreType.GenreName = @search;", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = search;
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MovieID"];
                    string title = (string)rdr["Title"];
                    string description = (string)rdr["Description"];
                    string date = (string)rdr["Release_date"];
                    Movie movie = new Movie(id,title, description, date);
                    genres.Add(movie);
                }
                return genres;
            }
        }


        public static Actor InsertActor(Actor actor)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Actors(FirstName,LastName) OUTPUT INSERTED.ActorID values(@fn,@ln)", connection);
                cmd.Parameters.Add(new SqlParameter("@fn", actor.Firstname));
                cmd.Parameters.Add(new SqlParameter("@ln", actor.Lastname));
                int newId = (Int32)cmd.ExecuteScalar();
                actor.ID = newId;
            }
            return actor;
        }
        public static Movie InsertMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Movies(Title,Release_date,Description) OUTPUT INSERTED.MovieID values(@tit,@rel,@des)", connection);
                cmd.Parameters.Add(new SqlParameter("@tit", movie.Title));
                cmd.Parameters.Add(new SqlParameter("@rel", movie.Date));
                cmd.Parameters.Add(new SqlParameter("@des", movie.Description));
                int newId = (Int32)cmd.ExecuteScalar();
                movie.ID = newId;
            }
            return movie;
        }
        public static Genre InsertGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into GenreType(GenreName) OUTPUT INSERTED.GenreID values(@gn)", connection);
                cmd.Parameters.Add(new SqlParameter("@gn", genre._Genre));
                int newId = (Int32)cmd.ExecuteScalar();
                genre.ID = newId;
            }
            return genre;
        }
        public static Movie UpdateMovie(Movie movie,int update)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update Movies SET Movies.Title = @tit,Movies.Release_date = @rel, Movies.Description = @des WHERE Movies.MovieID = @update", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@update";
                sp.Value = update;
                cmd.Parameters.Add(sp);
                cmd.Parameters.Add(new SqlParameter("@tit", movie.Title));
                cmd.Parameters.Add(new SqlParameter("@rel", movie.Date));
                cmd.Parameters.Add(new SqlParameter("@des", movie.Description));
                cmd.ExecuteNonQuery();
            }
            return movie;
        }
        public static Actor UpdateActor(Actor actor, int update)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update Actors SET Actors.FirstName = @name,Actors.LastName = @last WHERE Actors.ActorID = @update", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@update";
                sp.Value = update;
                cmd.Parameters.Add(sp);
                cmd.Parameters.Add(new SqlParameter("@name", actor.Firstname));
                cmd.Parameters.Add(new SqlParameter("@last", actor.Lastname));
                cmd.ExecuteNonQuery();
            }
            return actor;
        }
        public static Genre UpdateGenre(Genre genre, int update)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update GenreType SET GenreType.GenreName = @name WHERE GenreType.GenreID = @update", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@update";
                sp.Value = update;
                cmd.Parameters.Add(sp);
                cmd.Parameters.Add(new SqlParameter("@name", genre._Genre));
                cmd.ExecuteNonQuery();
            }
            return genre;
        }

        public static string DeleteMovie(Movie movie, string delmovie)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Movies WHERE Movies.Title = @moviename", connection);
                SqlParameter sp = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@moviename", movie.Title));
                cmd.ExecuteNonQuery();
            }
            return movie.Title + " Has been deleted";
        }
        public static string DeleteActor(Actor actor, string delactor)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Actors WHERE Actors.FirstName = @firstname", connection);
                SqlParameter sp = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@firstname", actor.Firstname));
                cmd.ExecuteNonQuery();
            }
            return actor.Firstname + " Has been deleted";
        }
        public static string DeleteGenre(Genre genre, string delgenre)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM GenreType WHERE GenreType.GenreName = @genrename", connection);
                SqlParameter sp = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@genrename", genre._Genre));
                cmd.ExecuteNonQuery();
            }
            return genre._Genre + " Has been deleted";
        }

    }
}
