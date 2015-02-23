namespace MovingLetters
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

   public class MovingLtters
	{
	   public static void Main(string[] args)
		{
			string input = Console.ReadLine();
			string[] words = input.Split(' ');
			int longest = 0;

			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Length > longest)
				{
					longest = words[i].Length;
				}
			}

			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Length < longest)
				{
					int diff = longest - words[i].Length;
					StringBuilder eqWord = new StringBuilder();

					for (int j = 0; j < diff; j++)
					{
						eqWord.Append(" ");
					}

					words[i] = eqWord.ToString() + words[i];
                    eqWord.Clear();
				}
			}

			int index = longest - 1;
			StringBuilder text = new StringBuilder();

			while (longest > 0)
			{
				for (int i = 0; i < words.Length; i++)
				{
					if (words[i][index] != ' ')
					{
						text.Append(words[i][index]);
					} 
				}

				index--;
				longest--;
			}

		   string textNew = text.ToString();

		   for (int i = 0; i < textNew.Length; i++)
			{
				int place = char.ToUpper(textNew[i]) - 65 + 1;               

                if (place > textNew.Length - i)
                {
                    place = place - (textNew.Length - i); 
                }
                else
                {
                    place = i + place;
                }

                while (place > textNew.Length - 1)
                {
                    place = place - textNew.Length;
                }	
				text.Remove(i, 1);
				text.Insert(place, textNew[i]);
				textNew = text.ToString();             
			}

		   Console.WriteLine(text);
		}
	}
}
