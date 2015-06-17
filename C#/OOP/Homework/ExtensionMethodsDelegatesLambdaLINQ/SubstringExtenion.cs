
namespace ExtensionMethodsDelegatesLambdaLINQ
{
    using System.Text;

    public static class SubstringExtenion
    {
        // Problem 1
        public static StringBuilder Substring(this StringBuilder sb, int index)
        {
            StringBuilder temp = new StringBuilder();

            for (int i = index; i < sb.Length; i++)
            {
                temp.Append(sb[i]);
            }

            return temp;
        }

        public static StringBuilder Substring(this StringBuilder sb, int index, int len)
        {
            StringBuilder temp = new StringBuilder();
      
            for (int i = index; i < index + len; i++)
            {
                temp.Append(sb[i]);
            }

            return temp;
        }

        // Problem 2

    }
}
