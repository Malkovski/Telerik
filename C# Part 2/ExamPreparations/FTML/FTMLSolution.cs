namespace FTML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

   public class FTMLSolution
	{
	   public static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());

			for (int i = 0; i < num; i++)
			{
				StringBuilder line = new StringBuilder(Console.ReadLine());
				int index = 0;
				while (index >= 0)
				{                   
					string lineAsString = line.ToString();
					index = lineAsString.IndexOf('/');
					if (index >= 0)
					{
						int len = lineAsString.Length - (lineAsString.Length - index) - 1;
						string lineSmall = lineAsString.Substring(0, len);
						int firstIndex = lineSmall.LastIndexOf('<');
						if (firstIndex >= 0)
						{
							string piece = lineSmall.Substring(firstIndex);
							line = FakeTranslator(line, piece, firstIndex, index);
						}
						else
						{

							if (line[index + 1] == 'd' || line[index + 1] == 'r')
							{
								line.Remove(index - 1, 6);
							}
							else if (line[index + 1] == 'l' || line[index + 1] == 'u')
							{
								line.Remove(index - 1, 8);
							}
							else
							{
								line.Remove(index - 1, 9);
							}                          
						}
					}
					else
					{
						line.Replace("<del>", "");
						line.Replace("<rev>", "");
						line.Replace("<upper>", "");
						line.Replace("<lower>", "");
						line.Replace("<toggle>", "");
						Console.WriteLine(line.ToString());
					}                
				}                      
			}
		}

	   private static StringBuilder FakeTranslator(StringBuilder line, string part, int k, int j)
	   {
		   int len = j - k;
		   if (part[1] == 'd')
		   {
			   line.Remove(k, len + 5);
		   }
		   else if (part[1] == 'r')
		   {
			   line.Remove(k, len + 5);
			   part = part.Substring(5);

			   for (int i = 0; i < part.Length; i++)
			   {
				   line.Insert(k, part[i]);
			   }
			   
		   }
		   else if (part[1] == 'l')
		   {
			   line.Remove(k, len + 7);
			   part = part.Substring(7);
			   part = part.ToLower();
			   line.Insert(k, part);
		   }
		   else if (part[1] == 'u')
		   {
			   line.Remove(k, len + 7);
			   part = part.Substring(7);
			   part = part.ToUpper();
			   line.Insert(k, part);
		   }
		   else if (part[1] == 't')
		   {
			   line.Remove(k, len + 8);
			   part = part.Substring(8);
			   string temp = string.Empty;

			   for (int i = 0; i < part.Length; i++)
			   {
				   if (char.IsUpper(part[i]))
				   {
					   temp += part[i].ToString().ToLower();
				   }
				   else
				   {
					   temp += part[i].ToString().ToUpper();
				   }
			   }
			   line.Insert(k, temp);
		   }

		   return line;
	   }
	}
}
