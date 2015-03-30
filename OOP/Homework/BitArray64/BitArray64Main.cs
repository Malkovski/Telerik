namespace BitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitArray64Main
    {
        public static void Main()
        {
            BitArray64Class first = new BitArray64Class(4444);
            BitArray64Class second = new BitArray64Class(3333);

            Console.WriteLine("First number in bits is:");
 
            foreach (var bit in first)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Second number in bits is:");

            foreach (var bit in second)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Bit from number {0} in position 15 is {1}",first.Number, first[15]);

            Console.WriteLine("Is {0} == {1} -> {2}", first.Number, second.Number, first == second);
            Console.WriteLine("Is {0} != {1} -> {2}", first.Number, second.Number, first != second);
            Console.WriteLine("Is {0} equals {1} -> {2}", first.Number, second.Number, first.Equals(second));
        }
    }
}
