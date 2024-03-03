using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloTest;

class Program
{
    static void Main(string[] args)
    {
        int rating = 0;
        int ratingTrue = 1200;
        int k = 40;
        int neededGames;
        int runs = 1000000;
        int[] cycles = new int[runs];
        int Score;
        Random rnd = new Random();

        for (int i = 0; i < runs; i++) {
            rating = 1000;

            neededGames = 0;
            while ( rating <= (ratingTrue - 70) || rating >= (ratingTrue + 70))
            {
                Score = 0;
                double Expected = 1 / (1 + (double)Math.Pow(10.00, (rating - ratingTrue) / 400));

                if (rnd.NextDouble() < Expected)
                {
                    Score = 1;
                }
                
                double S = (double) Score;
                double E = 0.5;

                rating = Convert.ToInt32(Math.Round( (double)rating + ((double)k * (S - E)) )) ;
                neededGames++;
            }
            cycles[i] = neededGames;
        }
        Console.WriteLine(cycles.Average());
        Console.ReadLine();

    }
}

