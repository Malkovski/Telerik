namespace Task3SequenceInMatrix
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

   public class SequenceInMatrix
	{
	   public static void Main(string[] args)
		{
			//string[,] matrixOfStrings =  
			//{ 
			// {"ha", "fifi", "ho", "hi"},
			// {"fo", "ha", "hi", "xx"},
			// {"xxx", "ho", "ha", "xx"} 
			//};

			string[,] matrixOfStrings = 
			{ 
				{"s", "qq", "s"},
				{"pp", "pp", "s"},
				{"pp", "qq", "s"} 
			};

			int n = matrixOfStrings.GetLength(0);
			int m = matrixOfStrings.GetLength(1);    
			string repElement = string.Empty;
			int count = 1;
			int maxCount = 0;
			int tempMax = 0;
		   
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					int line = j;
					int vert = i;
				   

					while (line < m - 1)
					{
						if (matrixOfStrings[i, j] == matrixOfStrings[i, line + 1])
						{                          
							count++;
							line++;
							tempMax = count;
							maxCount = IsMaxCount(count, maxCount);

							if (tempMax >= maxCount)
							{
								repElement = matrixOfStrings[i, line]; 
							}                         
						}
						else
						{
							count = 1;
							break;
						}                     
					}

					count = 1;
				
					while (vert < n -1)
					{
						if (matrixOfStrings[i, j] == matrixOfStrings[vert + 1, j])
						{                          
							count++;
							vert++;
							tempMax = count;
							maxCount = IsMaxCount(count, maxCount);

							if (tempMax >= maxCount)
							{
								repElement = matrixOfStrings[vert, j];
							}
						}
						else
						{
							count = 1;
							break;
						}
					}

					count = 1;

					while (line < n - 1 && vert < m - 1)
					{
						if (matrixOfStrings[i, j] == matrixOfStrings[line + 1, vert + 1])
						{                                                 
							count++;
							line++;
							vert++;
							tempMax = count;
							maxCount = IsMaxCount(count, maxCount);

							if (tempMax >= maxCount)
							{
								repElement = matrixOfStrings[i, j];
							}
						}
						else
						{ 
							count = 1;
							break;
						}
					}

					count = 1;
				}
			}

			string result = string.Empty;

		   for (int i = 0; i < maxCount; i++)
			{
				result += repElement;
				if (i < maxCount - 1)
				{
					result += ", ";  
				}	 
			}
		 
		   Console.WriteLine("Same string repeated {0} times. = {1}", maxCount, result);
		}

	   private static int IsMaxCount(int count, int maxCount)
	   {
		   if (count > maxCount)
		   {
			   maxCount = count;
			   count = 1;
		   }

		   return maxCount;
	   }
	}
}
