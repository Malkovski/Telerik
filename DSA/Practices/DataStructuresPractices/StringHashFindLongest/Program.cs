namespace StringHashFindLongest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            int maxLen = Solve(str1, str2);
            Console.WriteLine(maxLen);
        }

        private static int Solve(string str1, string str2)
        {
            int left = 0;
            int right = Math.Min(str1.Length, str2.Length);

            if (left == 0 && right == 0)
            {
                return 0;
            }

            Hash.ComputePowers(Math.Min(str1.Length, str2.Length));

            while (left <  right)
            {
                var middle = (left + right) / 2;

                bool hasFoundMatch = CheckForMatch(str1, str2, middle);

                if (hasFoundMatch)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return right - 1;
        }

        private static bool CheckForMatch(string str1, string str2, int length)
        {
            var hash1 = new Hash(str1.Substring(0, length));

            HashSet<ulong> hashes1 = new HashSet<ulong>(); 
            HashSet<ulong> hashes2 = new HashSet<ulong>();
           // HashSet<ulong> hashes3 = new HashSet<ulong>();

            hashes1.Add(hash1.Value1);
            hashes2.Add(hash1.Value2);
           // hashes3.Add(hash1.Value3);

            for (int i = 0; i < str1.Length - length; i++)
            {
                hash1.Add(str1[length + i]);
                hash1.Remove(str1[i], length);
                  
                hashes1.Add(hash1.Value1);
                hashes2.Add(hash1.Value2);
               // hashes3.Add(hash1.Value3);
            }

            var hash2 = new Hash(str2.Substring(0, length));

            if (hashes1.Contains(hash2.Value1) && hashes2.Contains(hash2.Value2))// && hashes3.Contains(hash2.Value3))
            {
                return true;
            }

            for (int i = 0; i < str2.Length - length; i++)
            {
                hash2.Add(str2[length + i]);
                hash2.Remove(str2[i], length);

                if (hashes1.Contains(hash2.Value1) && hashes2.Contains(hash2.Value2))// && hashes3.Contains(hash2.Value3))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Hash
    {
        private const ulong BASE1 = 401;
        private const ulong BASE2 = 257;
        //private const ulong BASE3 = 127;

        private const ulong MOD1 = 1000000033;
        private const ulong MOD2 = 1000000007;

        private static ulong[] powers1;
        private static ulong[] powers2;
        //private static ulong[] powers3;

        public static void ComputePowers(int n)
        {
            powers1 = new ulong[n + 1];
            powers2 = new ulong[n + 1];
           // powers3 = new ulong[n + 1];
            powers1[0] = 1;
            powers2[0] = 1;
            //powers3[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers1[i + 1] = powers1[i] * BASE1 % MOD1;
                powers2[i + 1] = powers2[i] * BASE2 % MOD2;
                //powers3[i + 1] = powers3[i] * BASE3 % MOD;
            }
        }

        public ulong Value1 { get; private set; }
        public ulong Value2 { get; private set; }
        //public ulong Value3 { get; private set; }

        public Hash(string str)
        {
            this.Value1 = 0;
            this.Value2 = 0;
            //this.Value3 = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value1 = (this.Value1 * BASE1 + c) % MOD1;
            this.Value2 = (this.Value2 * BASE2 + c) % MOD2;
            //this.Value3 = (this.Value3 * BASE3 + c) % MOD;
        } 

        public void Remove(char c, int n)
        {
            this.Value1 = (MOD1 + this.Value1 - powers1[n] * c % MOD1) % MOD1;
            this.Value2 = (MOD2 + this.Value2 - powers2[n] * c % MOD2) % MOD2;
           // this.Value3 = (MOD + this.Value3 - powers3[n] * c % MOD) % MOD;
        }
    }
}
