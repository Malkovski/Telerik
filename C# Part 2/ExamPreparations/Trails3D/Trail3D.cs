namespace Trails3D
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

   public class Trail3D
	{
	   public static void Main(string[] args)
		{
			string dims = Console.ReadLine();
			string redMoves = Console.ReadLine();
			string blueMoves = Console.ReadLine();
			int x = int.Parse(dims[0].ToString());
			int y = int.Parse(dims[2].ToString());
			int z = int.Parse(dims[4].ToString());
			int height = y + 1;
			int width = x*2 + ((z - 2) * 2);
			int[,] grid = new int[height, width];
			string redRoad = ClearRoad(redMoves);
			string blueRoad = ClearRoad(blueMoves);
			bool redCrush = false;
			bool blueCrush = false;
			int redH = y / 2;
			int redW = 0;
			int blueH = y / 2;
			int blueW = (x + z);
			int counter = 0;

		  
				int shortest = 0;
				if (redRoad.Length < blueRoad.Length)
				{
					shortest = redRoad.Length;
				}
				else
				{
					shortest = blueRoad.Length;
				}

				grid[redH, redW] = 1;
				grid[blueH, blueW] = 2;
                bool curve = false;
                bool turn = false;
                int direction = 0;
                int prevDirect = 0;
                int way = 0;
                int prevWay = 0;

                

				for (int i = 0; i < shortest; i++)
				{
                    ///// RED SIDE CHECKING

                    if (i == 0)
                    {
                        if (redRoad[0] == 'M')
                        {
                            direction = 1;
                            redW++;
                            if (grid[redH, redW] == 0)
                            {
                                grid[redH, redW] = 1;
                            }
                            else
                            {
                                redCrush = true;
                            }
                           
                        }
                        else if (redRoad[0] == 'L')
                        {
                            direction = 2;
                        }
                        else if (redRoad[0] == 'R')
                        {
                            direction = 3;
                        }

                        prevDirect = direction;
                    }
                    else
                    {
                        if (redRoad[i] == 'M')
                        {
                            if (direction == 1)
                            {
                                redW++;
                                if (grid[redH, redW] == 0)
                                {
                                    grid[redH, redW] = 1;
                                }
                                else
                                {
                                    redCrush = true;
                                }
                            }
                            else if (direction == 2)
                            {
                                if (prevDirect == 3)
                                {                                   
                                    redW++;
                                    if (grid[redH, redW] == 0)
                                    {
                                        grid[redH, redW] = 1;
                                    }
                                    else
                                    {
                                        redCrush = true;
                                    }
                                }
                                else if (prevDirect == 1 || prevDirect == 2)
                                {
                                    redH--;
                                    if (grid[redH, redW] == 0)
                                    {
                                        grid[redH, redW] = 1;
                                    }
                                    else
                                    {
                                        redCrush = true;
                                    }
                                }
                               
                            }
                            else
                            {
                                if (prevDirect == 2)
                                {
                                    direction = 1;
                                    redW++;

                                    if (grid[redH, redW] == 0)
                                    {
                                        grid[redH, redW] = 1;
                                    }
                                    else
                                    {
                                        redCrush = true;
                                    }
                                }
                                else if (prevDirect == 1 || prevDirect == 3)
                                {
                                    redH++;
                                    if (grid[redH, redW] == 0)
                                    {
                                        grid[redH, redW] = 1;
                                    }
                                    else
                                    {
                                        redCrush = true;
                                    }
                                }
                               
                            }

                            prevDirect = direction;
                        }
                        else if (redRoad[i] == 'L')
                        {
                            direction = 2;
                        }
                        else if (redRoad[i] == 'R')
                        {
                            direction = 3;
                        }
                    }

                    ////BLUE SIDE CHECKING

                    if (i == 0)
                    {
                        if (blueRoad[0] == 'M')
                        {
                            way = 1;
                            blueW--;

                            if (grid[blueH, blueW] == 0)
                            {
                                grid[blueH, blueW] = 1;
                            }
                            else
                            {
                                blueCrush = true;
                            }

                        }
                        else if (blueRoad[0] == 'L')
                        {
                            way = 2;
                        }
                        else if (blueRoad[0] == 'R')
                        {
                            way = 3;
                        }

                        prevWay = way;
                    }
                    else
                    {
                        if (blueRoad[i] == 'M')
                        {
                            if (way == 1)
                            {
                                blueW--;
                                if (grid[blueH, blueW] == 0)
                                {
                                    grid[blueH, blueW] = 1;
                                }
                                else
                                {
                                    blueCrush = true;
                                }
                            }
                            else if (way == 2)
                            {
                                if (prevWay == 3)
                                {
                                    blueW--;
                                    if (grid[blueH, blueW] == 0)
                                    {
                                        grid[blueH, blueW] = 1;
                                    }
                                    else
                                    {
                                        blueCrush = true;
                                    }
                                }
                                else if (prevWay == 1 || prevWay == 2)
                                {
                                    blueH++;
                                    if (grid[blueH, blueW] == 0)
                                    {
                                        grid[blueH, blueW] = 1;
                                    }
                                    else
                                    {
                                        blueCrush = true;
                                    }
                                }

                            }
                            else
                            {
                                if (prevWay == 2)
                                {
                                    blueW--;
                                    if (grid[blueH, blueW] == 0)
                                    {
                                        grid[blueH, blueW] = 1;
                                    }
                                    else
                                    {
                                        blueCrush = true;
                                    }
                                }
                                else if (prevWay == 1)
                                {
                                    blueH--;
                                    if (grid[blueH, blueW] == 0)
                                    {
                                        grid[blueH, blueW] = 1;
                                    }
                                    else
                                    {
                                        blueCrush = true;
                                    }
                                }
                                else
                                {
                                    way = 1;

                                    if (grid[blueH, blueW] == 0)
                                    {
                                        grid[blueH, blueW] = 1;
                                    }
                                    else
                                    {
                                        blueCrush = true;
                                    }
                                }

                            }

                            prevWay = way;
                        }
                        else if (blueRoad[i] == 'L')
                        {
                            way = 2;
                        }
                        else if (blueRoad[i] == 'R')
                        {
                            way = 3;
                        }
                    }

					if (redCrush || blueCrush)
					{
						//break;
					}
                    PrintGrid(grid);
				}

				

			if (redCrush && !blueCrush)
			{
				Console.WriteLine("BLUE");
				Console.WriteLine(counter);
			}
			else if (blueCrush && !redCrush)
			{
				Console.WriteLine("RED");
				Console.WriteLine(counter);
			}
			else
			{
				Console.WriteLine("DRAW");
				Console.WriteLine(counter);
			}

		}

	   private static void PrintGrid(int[,] grid)
	   {
		   for (int i = 0; i < grid.GetLength(0); i++)
		   {
			   for (int j = 0; j < grid.GetLength(1); j++)
			   {
				   Console.Write(grid[i, j]);
			   }
			   Console.WriteLine();
		   }
	   }

	   private static string ClearRoad(string moves)
	   {
		   StringBuilder road = new StringBuilder();

		   for (int i = 0; i < moves.Length; i++)
		   {
			   if (char.IsDigit(moves[i]))
			   {  
					for (int j = 0; j < int.Parse(moves[i].ToString()) - 1; j++)
					{
						road.Append(moves[i + 1]);
					}                                                          
			   }
			   else
			   {
				   road.Append(moves[i]);
			   }
		   }
		   string redRoad = road.ToString();
		   return redRoad;
	   }
	}
}
