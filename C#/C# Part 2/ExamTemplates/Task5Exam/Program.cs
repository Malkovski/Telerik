using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string cats = Console.ReadLine();
            int catNum = int.Parse(cats.Substring(0, cats.Length - (cats.Length - cats.IndexOf(' '))));
            string songs = Console.ReadLine();
            int songNum = int.Parse(songs.Substring(0, songs.Length - (songs.Length - songs.IndexOf(' '))));
            List<int> cat = new List<int>();
            List<int> song = new List<int>();

            
            while (Console.ReadLine() != "Mew!")
            {
                string line = Console.ReadLine();
                string[] parts = line.Split(' ');
                song.Add(int.Parse(parts[4].ToString()));
                cat.Add(int.Parse(parts[1].ToString()));
                
            }

            int[,] grid = new int[songNum + 1, catNum + 1];

            for (int i = 0; i < cat.Count; i++)
            {
                grid[song[i], cat[i]] = 1;
                
            }

        

            for (int i = 1; i < songNum + 1; i++)
            {
                for (int j = 1; j < catNum + 1 ; j++)
                {
                    if (grid[i - 1, j] > grid[i, j - 1])
                    {
                        grid[i, j] += grid[i - 1, j];
                    }
                    else
                    {
                        grid[i, j] += grid[i, j - 1];
                    }
                   
                }
            }

            Console.WriteLine("No concert!");
        }
    }
}
