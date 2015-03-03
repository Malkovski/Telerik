namespace KukataIsDancing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class KukataIsDancing
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string[] moves = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                moves[i] = Console.ReadLine();
            }

            string[,] dancing =
            {
                {"R", "B", "R"},
                {"B", "G", "B"},
                {"R", "B", "R"}
            };

            int row = 1;
            int col = 1;
            int dir = 0;
            string pos = dancing[row, col + 1];
            string nextPos = dancing[row, col];

            for (int l = 0; l < moves.Length; l++)
            {
                for (int i = 0; i < moves[l].Length; i++)
                {
                    if (moves[l][i] == 'W')
                    {
                        pos = DancindSteps(dancing, moves[l][i], row, col, nextPos);
                    }
                     
                }

                Console.WriteLine(WinnerIs(pos));
            }
        }

        private static string DancindSteps(string[,] dancing, char p, int row, int col, string nextPos)
        {
            if (row == 1)
            {
                if (p == 'L')
                {
                                      
                }
            }
            else if (row == 0)
            {
                
            }
            else if (row == 2)
            {
                
            }
            
        }

        private static string WinnerIs(string pos)
        {
            switch (pos)
            {
                case "B": pos = "BLUE";
                    break;
                case "R": pos = "RED";
                    break;
                case "G": pos = "GREEN";
                    break;
                default:
                    break;
            }

            return pos;
        }
    }
}