

namespace MasivCompare
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class MasivCompare
    {
        static void Main(string[] args)
        {
                       
                Console.WriteLine("Size of first array is?");
                int n = int.Parse(Console.ReadLine());
                int[] arr1 = new int[n];
                for (int i = 0; i < n; i++)
                {
                    //Console.WriteLine("Enter elements!");
                    arr1[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Size of second array is?");
                int m = int.Parse(Console.ReadLine());
                int[] arr2 = new int[m];
                for (int j = 0; j < m; j++)
                {
                    // Console.WriteLine("Enter elements!");
                    arr2[j] = int.Parse(Console.ReadLine());
                }
                    if (n > m)
                    {
                        Console.WriteLine("First array is bigger!");
                        
                    }
                      if (n < m)
                      {
                            Console.WriteLine("Second array is bigger!");
                           
                      }
                                                                      
                       if (n == m)

                       {
                           for (int i = 0; i < n; i++)
                            {
                                                                      
                                        if (arr1[i] > arr2[i])
                                        {
                                            Console.WriteLine("First array is bigger!");
                                            return;
                                            
                                        }
                                        else
                                        {
                                            if (arr1[i] < arr2[i])
                                            {
                                                Console.WriteLine("Second array is bigger!");
                                                return;
                                                
                                            }                                          
                                                   
                                               
                                        }

                            }
                                           
                       }
                       Console.WriteLine("Arrays are equal!");                                                      
        }                  
    } 
}
