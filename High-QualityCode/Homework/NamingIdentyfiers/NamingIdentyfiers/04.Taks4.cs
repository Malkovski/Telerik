namespace GameOfMines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mines
    {
        public static void Main(string[] arguments)
        {
            const int MaxMoves = 35;

            string currentCommand = string.Empty;
            char[,] battlefield = CreateBattlefield();
            char[,] minesPossitions = GenerateMinesPossitions();
            int counter = 0;
            bool explosion = false;
            List<Points> champions = new List<Points>(6);
            int row = 0;
            int col = 0;
            bool startGame = true;
            bool endGame = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " currentCommand 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoard(battlefield);
                    startGame = false;
                }

                Console.Write("Daj row i col : ");
                currentCommand = Console.ReadLine().Trim();

                if (currentCommand.Length >= 3)
                {
                    if (int.TryParse(currentCommand[0].ToString(), out row) &&
                    int.TryParse(currentCommand[2].ToString(), out col) &&
                        row <= battlefield.GetLength(0) && col <= battlefield.GetLength(1))
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        GetRanking(champions);
                        break;

                    case "restart":
                        battlefield = CreateBattlefield();
                        minesPossitions = GenerateMinesPossitions();
                        PrintBoard(battlefield);
                        explosion = false;
                        startGame = false;
                        break;

                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;

                    case "turn":
                        if (minesPossitions[row, col] != '*')
                        {
                            if (minesPossitions[row, col] == '-')
                            {
                                MakeNewTurn(battlefield, minesPossitions, row, col);
                                counter++;
                            }

                            if (MaxMoves == counter)
                            {
                                endGame = true;
                            }
                            else
                            {
                                PrintBoard(battlefield);
                            }
                        }
                        else
                        {
                            explosion = true;
                        }

                        break;

                    default:
                        Console.WriteLine("\nGreshka! nevalidna currentCommand\n");
                        break;
                }

                if (explosion)
                {
                    PrintBoard(minesPossitions);
                    Console.Write(
                        "\nHrrrrrr! Umria gerojski s {0} to4ki. " + 
                        "Daj si niknejm: ", 
                        counter);
                    string playerName = Console.ReadLine();
                    Points currentPlayerPoints = new Points(playerName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(currentPlayerPoints);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < currentPlayerPoints.Points)
                            {
                                champions.Insert(i, currentPlayerPoints);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Points r1, Points r2) => r2.Points.CompareTo(r1.Points));
                    GetRanking(champions);

                    battlefield = CreateBattlefield();
                    minesPossitions = GenerateMinesPossitions();
                    counter = 0;
                    explosion = false;
                    startGame = true;
                }

                if (endGame)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoard(minesPossitions);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string playerName = Console.ReadLine();
                    Points currentPlayerPoints = new Points(playerName, counter);
                    champions.Add(currentPlayerPoints);
                    GetRanking(champions);
                    battlefield = CreateBattlefield();
                    minesPossitions = GenerateMinesPossitions();
                    counter = 0;
                    endGame = false;
                    startGame = true;
                }
            }
            while (currentCommand != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void GetRanking(List<Points> pointsList)
        {
            Console.WriteLine("\nTo4KI:");
            if (pointsList.Count > 0)
            {
                for (int i = 0; i < pointsList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, pointsList[i].Name, pointsList[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeNewTurn(char[,] battlefield, char[,] mines, int row, int col)
        {
            char minePossition = GetMinePossition(mines, row, col);
            mines[row, col] = minePossition;
            battlefield[row, col] = minePossition;
        }

        private static void PrintBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < boardRows; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBattlefield()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateMinesPossitions()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> randomPossitions = new List<int>();

            while (randomPossitions.Count < 15)
            {
                Random random = new Random();
                int randomPossition = random.Next(50);
                if (!randomPossitions.Contains(randomPossition))
                {
                    randomPossitions.Add(randomPossition);
                }
            }

            foreach (int possition in randomPossitions)
            {
                int row = possition / cols;
                int col = possition % cols;

                if (col == 0 && possition != 0)
                {
                    row--;
                    col = cols;
                }
                else
                {
                    row++;
                }

                field[row, col - 1] = '*';
            }

            return field;
        }

        private static void CalculateResult(char[,] field)
        {
            int kol = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char kolkoo = GetMinePossition(field, i, j);
                        field[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char GetMinePossition(char[,] field, int fieldRow, int fieldCol)
        {
            int mineCount = 0;
            int rows = field.GetLength(0);
            int kols = field.GetLength(1);

            if (fieldRow - 1 >= 0)
            {
                if (field[fieldRow - 1, fieldCol] == '*')
                { 
                    mineCount++; 
                }
            }

            if (fieldRow + 1 < rows)
            {
                if (field[fieldRow + 1, fieldCol] == '*')
                { 
                    mineCount++; 
                }
            }

            if (fieldCol - 1 >= 0)
            {
                if (field[fieldRow, fieldCol - 1] == '*')
                { 
                    mineCount++;
                }
            }

            if (fieldCol + 1 < kols)
            {
                if (field[fieldRow, fieldCol + 1] == '*')
                { 
                    mineCount++;
                }
            }

            if ((fieldRow - 1 >= 0) && (fieldCol - 1 >= 0))
            {
                if (field[fieldRow - 1, fieldCol - 1] == '*')
                { 
                    mineCount++; 
                }
            }

            if ((fieldRow - 1 >= 0) && (fieldCol + 1 < kols))
            {
                if (field[fieldRow - 1, fieldCol + 1] == '*')
                { 
                    mineCount++; 
                }
            }

            if ((fieldRow + 1 < rows) && (fieldCol - 1 >= 0))
            {
                if (field[fieldRow + 1, fieldCol - 1] == '*')
                { 
                    mineCount++; 
                }
            }

            if ((fieldRow + 1 < rows) && (fieldCol + 1 < kols))
            {
                if (field[fieldRow + 1, fieldCol + 1] == '*')
                { 
                    mineCount++; 
                }
            }

            return char.Parse(mineCount.ToString());
        }

        public class Points
        {
            private string name;
            private int points;

            public Points()
            {
            }

            public Points(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }
        }
    }
}   