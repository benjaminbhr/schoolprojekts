using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class Program
    {
        static ConsoleKeyInfo UserKeyInput()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            return cki;
        }
        static void Menu()
        {
            bool showmenu = true;
            while (showmenu)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("        Movie Database");
                Console.WriteLine("================================");
                Console.WriteLine("(1) Show all movies!");
                Console.WriteLine("(2) Show all Actors");
                Console.WriteLine("(3) Search movies");
                Console.WriteLine("(4) Search Actors");
                Console.WriteLine("(5) Search Genres");
                Console.WriteLine("(6) Insert Actor");
                Console.WriteLine("(7) Insert Movie");
                Console.WriteLine("(8) Insert Genre");
                Console.WriteLine("(9) Show all genres");
                Console.WriteLine("(F1) Update movie");
                Console.WriteLine("(F2) Update actor");
                Console.WriteLine("(F3) Update Genre");
                Console.WriteLine("(F4) Delete Movie");
                Console.WriteLine("(F5) Delete Actor");
                Console.WriteLine("(F6) Delete Genre");
                switch (UserKeyInput().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("These are all the movies in the database!");
                        List<Movie> movie = MovieManager.GetMovies();
                        foreach (Movie item in movie)
                        {
                            Console.WriteLine("Movie ID:(" + item.ID + ")");
                            Console.WriteLine("Movie Title: " + item.Title);
                            Console.WriteLine("Movie Description: " + item.Description);
                            Console.WriteLine("Movie Release date: " + item.Date + "\n");
                        }
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("These are all the actors in the database!");
                        List<Actor> actor = MovieManager.GetActors();
                        foreach (Actor item in actor)
                        {
                            Console.WriteLine("Actor ID:(" + item.ID + ")");
                            Console.WriteLine("Actor Firstname: " + item.Firstname);
                            Console.WriteLine("Actor Lastname: " + item.Lastname);
                        }
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Type the name of the movie you want to find!");
                        string searchmovie = Console.ReadLine();
                        foreach (Movie item in MovieManager.SearchMovies(searchmovie))
                        {
                            Console.WriteLine("Movie ID:(" + item.ID + ")");
                            Console.WriteLine("Movie Title: " + item.Title);
                            Console.WriteLine("Movie Description: " + item.Description + "\n");
                        }
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Type the name of the actor you want to find!");
                        string searchactor = Console.ReadLine();
                        foreach (Actor item in MovieManager.SearchActor(searchactor))
                        {
                            Console.WriteLine("Movie ID:(" + item.ID + ")");
                            Console.WriteLine("Movie Title: " + item.Firstname);
                            Console.WriteLine("Movie Description: " + item.Lastname + "\n");
                        }
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Type the name of the genre you want to find movies from");
                        string searchgenre = Console.ReadLine();
                        foreach (Movie item in MovieManager.SearchGenres(searchgenre))
                        {
                            Console.WriteLine("Genre ID:(" + item.ID + ")");
                            Console.WriteLine("Genre Name: " + item.Title);
                            Console.WriteLine("Movie Description: " + item.Description + "\n");
                        }
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Type the firstname and lastname of the actor you want to add");
                        string firstname = Console.ReadLine();
                        string lastname = Console.ReadLine();
                        MovieManager.InsertActor(new Actor(firstname, lastname));
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("Type the movie name");
                        string moviename = Console.ReadLine();
                        Console.WriteLine("Type the movie date (YYYY-MM-DD)");
                        string date = Console.ReadLine();
                        Console.WriteLine("Type the description of the movie");
                        string des = Console.ReadLine();
                        MovieManager.InsertMovie(new Movie(moviename,des,date));
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("Type the genre name");
                        string genrename = Console.ReadLine();
                        MovieManager.InsertGenre(new Genre(genrename));
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.WriteLine("These are all the genres in the database!");
                        List<Genre> genres = MovieManager.GetGenres();
                        foreach (Genre item in genres)
                        {
                            Console.WriteLine("Genre name: "+ item._Genre);
                        }
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.F1:
                        Console.Clear();
                        Console.WriteLine("Type the index of the movie you want to change");
                        int updatemovie = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Type the new movie name");
                        string upmoviename = Console.ReadLine();
                        Console.WriteLine("Type the new movie date (YYYY-MM-DD)");
                        string update = Console.ReadLine();
                        Console.WriteLine("Type the new description of the movie");
                        string updes = Console.ReadLine();
                        MovieManager.UpdateMovie(new Movie(upmoviename, updes, update),updatemovie);
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.F2:
                        Console.Clear();
                        Console.WriteLine("Type the index of the actor you want to change");
                        int updateactor = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Type the new actor name");
                        string upactorname = Console.ReadLine();
                        Console.WriteLine("Type the new actor last name");
                        string upactorlast = Console.ReadLine();
                        MovieManager.UpdateActor(new Actor(upactorname, upactorlast), updateactor);
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.F3:
                        Console.Clear();
                        Console.WriteLine("Type the index of the genre you want to change");
                        int updategenre = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Type the new genre name");
                        string upname = Console.ReadLine();
                        MovieManager.UpdateGenre(new Genre(upname), updategenre);
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.F4:
                        Console.Clear();
                        Console.WriteLine("Type the name of the movie you want to delete");
                        string delmoviename = Console.ReadLine();
                        Console.WriteLine(MovieManager.DeleteMovie(new Movie(delmoviename, null, null), delmoviename));
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.F5:
                        Console.Clear();
                        Console.WriteLine("Type the name of the actor you want to delete");
                        string delactor = Console.ReadLine();
                        Console.WriteLine(MovieManager.DeleteActor(new Actor(delactor, null), delactor));
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.F6:
                        Console.Clear();
                        Console.WriteLine("Type the name of the genre you want to delete");
                        string delgenre = Console.ReadLine();
                        Console.WriteLine(MovieManager.DeleteGenre(new Genre(delgenre), delgenre));
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
