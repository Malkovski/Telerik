//int i=0;
//for (i = 0; i < 100;) 
//{
//   if (i % 10 == 0)
//   {
//    Console.WriteLine(array[i]);
//    if ( array[i] == expectedValue ) 
//    {
//       i = 666;
//    }
//    i++;
//   }
//   else
//   {
//        Console.WriteLine(array[i]);
//    i++;
//   }
//}
//// More code here
//if (i == 666)
//{
//    Console.WriteLine("Value Found");
//}

public class Loop
{
    private const int DevilNumber = 666;
    public int result = 0;

    public void SearchForValue() 
    {
        for (int i = 0; i < 100; i++) 
        {
           if (i % 10 == 0)
           {
               Console.WriteLine(array[i]);

            if (array[i] == expectedValue) 
            {
               result = DevilNumber;
            }
           }
           else
           {
                Console.WriteLine(array[i]);
           }
        }

        // More code here

        if (result == DevilNumber)
        {
            Console.WriteLine("Value Found");
        }
    }
    
}
