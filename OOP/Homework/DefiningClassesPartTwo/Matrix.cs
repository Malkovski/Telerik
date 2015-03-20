namespace DefiningClassesPartTwo
{
    using System;
    using System.Text;

    public class Matrix<T>  where T: IComparable
    {
        private const int DefaultRow = 4;
        private const int DefaultCol = 4;

        private T[,] grid;
        private int row;
        private int col;

        public Matrix() : this(DefaultRow, DefaultCol)
        {
        }

        public Matrix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.grid = new T[row, col];
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 1 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Entered value out of range!");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 1 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Input value out of range!");
                }

                this.col = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || row > int.MaxValue || col > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Input value(s) out of range!");
                }

                T result = this.grid[row, col];
                return result;
            }

            set
            {
                this.grid[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> gridOne, Matrix<T> gridTwo)
        {
            if (gridOne.Row != gridTwo.Row || gridOne.Col != gridTwo.Col)
            {
                throw new ArgumentException("Matrices must be equal size!");
            }

            Matrix<T> gridResult = new Matrix<T>(gridOne.Row, gridOne.Col);

            for (int i = 0; i < gridOne.Row; i++)
            {
                for (int j = 0; j < gridOne.Col; j++)
                {                 
                    gridResult[i, j] = (dynamic)gridOne[i, j] + gridTwo[i, j];
                }
            }

            return gridResult;
        }

        public static Matrix<T> operator -(Matrix<T> gridOne, Matrix<T> gridTwo)
        {
            if (gridOne.Row != gridTwo.Row || gridOne.Col != gridTwo.Col)
            {
                throw new ArgumentException("Matrices must be equal size!");
            }

            Matrix<T> gridResult = new Matrix<T>(gridOne.Row, gridOne.Col);

            for (int i = 0; i < gridOne.Row; i++)
            {
                for (int j = 0; j < gridOne.Col; j++)
                {
                    gridResult[i, j] = (dynamic)gridOne[i, j] - gridTwo[i, j];
                }
            }
            return gridResult;
        }

        public static Matrix<T> operator *(Matrix<T> gridOne, Matrix<T> gridTwo)
        {
            if (gridOne.Row != gridTwo.Col)
            {
                throw new ArgumentException("Rows  of the first matrix nad columns of the second matrix must be equal!!");
            }

            Matrix<T> gridResult = new Matrix<T>(gridOne.Row, gridTwo.Col);

            for (int i = 0; i < gridOne.Row; i++)
            {
                for (int j = 0; j < gridTwo.Col; j++)
                {
                    T result = (dynamic)0;

                    for (int k = 0; k < gridOne.Col; k++)
                    {
                         gridResult[i, j] = gridResult[i, j] + (dynamic)gridOne[i, k] * gridTwo[k, j];
                    }                     
                }
            }

            return gridResult;
        }

        public static bool operator true(Matrix<T> grid)
        {
            for (int i = 0; i < grid.Row; i++)
            {
                for (int j = 0; j < grid.Col; j++)
                {
                    if ((dynamic)grid[i, j] != 0)
                    {
                        return true;
                    }
                }			 
            }

            return false;
        }

        public static bool operator false(Matrix<T> grid)
        {
            for (int i = 0; i < grid.Row; i++)
            {
                for (int j = 0; j < grid.Col; j++)
                {
                    if ((dynamic)grid[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    info.Append(this.grid[i, j] + "\t");
                }

                info.AppendLine();
            }

            return info.ToString();
        }
    }
}
