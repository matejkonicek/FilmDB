using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public class Rating
        {
            public string Source { get; set; }
            public string Value { get; set; }
        }

        public class Movie
        {
            public string Title { get; set; }
            public string Released { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Actors { get; set; }
            public string Plot { get; set; }
            public string Language { get; set; }
            public string Awards { get; set; }
            public string Poster { get; set; }
            public List<Rating> Ratings { get; set; }
            public string Type { get; set; }
            public string Response { get; set; }
        }

        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            do
            {
                Console.Write("Enter the name of the movie you want to find: ");
                string movieName = Console.ReadLine();

                var response = await client.GetAsync($"http://www.omdbapi.com/?--yourkey--&t={movieName}");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var movie = JsonSerializer.Deserialize<Movie>(responseBody);

                if (movie.Response == "False")
                {
                    Console.WriteLine("Movie not found!");
                }
                else
                {
                    Console.WriteLine($"Title: {movie.Title}");
                    Console.WriteLine($"Type: {movie.Type}");
                    Console.WriteLine($"Released: {movie.Released}");
                    Console.WriteLine($"Runtime: {movie.Runtime}");
                    Console.WriteLine($"Genre: {movie.Genre}");
                    Console.WriteLine($"Lenguage: {movie.Language}");
                    Console.WriteLine($"Plot: {movie.Plot}");
                    Console.WriteLine($"Director: {movie.Director}");
                    Console.WriteLine($"Poster: {movie.Poster}");
                    Console.WriteLine($"Actors: {movie.Actors}");
                    Console.WriteLine($"Awards: {movie.Awards}");
                    Console.Write($"Ratings: ");
                    foreach (var rating in movie.Ratings)
                    {
                        Console.Write($"{rating.Source} ({rating.Value}), ");
                    }
                    Console.WriteLine();
                }

            } while (true);
        }
    }
}
