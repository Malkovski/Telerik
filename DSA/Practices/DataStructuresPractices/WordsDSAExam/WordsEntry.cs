namespace DataStructuresPractices
{
    using System;
    using System.Linq;

    public class WordsEntry
    {
        static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            int maxLen = Solve(word, text);
            Console.WriteLine(maxLen);
        }

        private static int Solve(string word, string text)
        {
            var matchesCount = 0;
            var w = word.Length;
            //Hash.ComputePowers(word.Length);

            

            for (int i = 0; i < word.Length; i++)
            {
                var firstMatchesCount = 0;
                var secondMatchesCount = 0;
                var partOne = word.Substring(0, i + 1);
                var partTwo = word.Substring(i + 1);
                int matched = 0;
                if (partOne != "")
                {
                   // firstMatchesCount = CheckForMatch(partOne, text);
                    int[] fl = new int[partOne.Length + 1];
                    fl[0] = -1;

                    for (int k = 1; k < partOne.Length; k++)
                    {
                        int j = fl[k];
                        while (j >= 0 && partOne[j] != partOne[k])
                        {
                            j = fl[j];
                        }
                        fl[k + 1] = j + 1;
                    }
                   
                    for (int j = 0; j < text.Length; j++)
                    {
                        while (matched >= 0 && text[i] != partOne[matched])
                        {
                            matched = fl[matched];
                        }

                        matched++;

                        if (matched == partOne.Length)
                        {
                            firstMatchesCount++;
                            matched = fl[matched];
                        }
                    }

                }
                else
                {
                    firstMatchesCount = 1;
                }

                if (partTwo != "")
                {
                    //secondMatchesCount = CheckForMatch(partTwo, text);
                    int[] fl = new int[partTwo.Length + 1];
                    fl[0] = -1;

                    for (int k = 1; k < partTwo.Length; k++)
                    {
                        int j = fl[k];
                        while (j >= 0 && partTwo[j] != partTwo[k])
                        {
                            j = fl[j];
                        }
                        fl[k + 1] = j + 1;
                    }
               
                    for (int j = 0; j < text.Length; j++)
                    {
                        while (matched >= 0 && text[i] != partTwo[matched])
                        {
                            matched = fl[matched];
                        }

                        matched++;

                        if (matched == partTwo.Length)
                        {
                            secondMatchesCount++;
                            matched = fl[matched];
                        }
                    }
                }
                else
                {
                    secondMatchesCount = 1;
                }

                matchesCount += (firstMatchesCount * secondMatchesCount);
            }

            return matchesCount;
        }

        private static int CheckForMatch(string wordPart, string text)
        {
            var count = 0;
            int n = text.Length;
            int m = wordPart.Length;
            Hash hpattern = new Hash(wordPart);
            Hash hwindow = new Hash(text.Substring(0, m));

            //HashSet<ulong> hashes1 = new HashSet<ulong>();
            //HashSet<ulong> hashes2 = new HashSet<ulong>();
            // HashSet<ulong> hashes3 = new HashSet<ulong>();


            if (hpattern.Value1 == hwindow.Value1)
            {
                count++;
            }

            for (int i = 1; i <= n - m; i++)
            {
                hwindow.Add(text[i + m - 1]);
                hwindow.Remove(text[i - 1], m);

                if (hpattern.Value1 == hwindow.Value1)
                {
                    count++;
                }
            }

            return count;
        }
    }

    public class Hash
    {
        private const ulong BASE1 = 401;
        //private const ulong BASE2 = 257;
        //private const ulong BASE3 = 127;

        private const ulong MOD1 = 1000000033;
        //private const ulong MOD2 = 1000000007;

        private static ulong[] powers1;
        //private static ulong[] powers2;
        //private static ulong[] powers3;

        public static void ComputePowers(int n)
        {
            powers1 = new ulong[n + 1];
            //powers2 = new ulong[n + 1];
            // powers3 = new ulong[n + 1];
            powers1[0] = 1;
            //powers2[0] = 1;
            //powers3[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers1[i + 1] = powers1[i] * BASE1 % MOD1;
                // powers2[i + 1] = powers2[i] * BASE2 % MOD2;
                //powers3[i + 1] = powers3[i] * BASE3 % MOD;
            }
        }

        public ulong Value1 { get; private set; }
        //public ulong Value2 { get; private set; }
        //public ulong Value3 { get; private set; }

        public Hash(string str)
        {
            this.Value1 = 0;
            //this.Value2 = 0;
            //this.Value3 = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value1 = (this.Value1 * BASE1 + c) % MOD1;
            //this.Value2 = (this.Value2 * BASE2 + c) % MOD2;
            //this.Value3 = (this.Value3 * BASE3 + c) % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value1 = (MOD1 + this.Value1 - powers1[n] * c % MOD1) % MOD1;
            //this.Value2 = (MOD2 + this.Value2 - powers2[n] * c % MOD2) % MOD2;
            // this.Value3 = (MOD + this.Value3 - powers3[n] * c % MOD) % MOD;
        }
    }
}
