namespace PermutationExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Program
    {
       public static void Main(string[] args)
        {
            PermutingCode perm = new PermutingCode();
            int num = int.Parse(Console.ReadLine());
            char[] text = new char[num];
            StringBuilder word = new StringBuilder(num);

            for (int i = 0; i < num; i++)
            {
                word.Append(Console.ReadLine());
            }
            string text1 = word.ToString();
            text = text1.ToCharArray();
            int result = perm.go(text, 0, text.Length - 1);
            Console.WriteLine(result);
        }
    }

    public class PermutingCode
    {
        int count = 0;
        private void swap(ref char a, ref char b)
        {
            if (a == b)
            {
                return;
            }

            a ^= b;
            b ^= a;
            a ^= b;
        }

        internal int go(char[] text, int k, int m)
        {
            
            int i;
            if (k == m)
            {
                List<string> bigList = new List<string>();
                StringBuilder word = new StringBuilder();
                bool wrong = true;
                char temp = ' ';

                for (int j = 0; j < text.Length; j++)
                {
                    if (temp != text[j])
                    {
                        temp = text[j];
                        word.Append(text[j]);
                    }
                    else
                    {
                        wrong = false;
                        word.Clear();
                        break;
                    }
                }

                if (wrong)
                {                 
                    for (int p = 0; p < bigList.Capacity; p++)
                    {
                        if (bigList[k] == word.ToString())
                        {      
                                wrong = false;
                        } 
                    }
                       
                    bigList.Add(word.ToString());
                    word.Clear();
                }
               
                if (wrong)
                {
                    count++;
                }            
            }
            else
                for (i = k; i <= m; i++)
                {
                    swap(ref text[k], ref text[i]);
                    go(text, k + 1, m);
                    swap(ref text[k], ref text[i]);
                }
            return count;
        } 
    }
}
