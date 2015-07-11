//Refactor the following code to apply variable usage and naming best practices:

//public void PrintStatistics(double[] arr, int count)
//{
//    double max, tmp;
//    for (int i = 0; i < count; i++)
//    {
//        if (arr[i] > max)
//        {
//            max = arr[i];
//        }
//    }
//    PrintMax(max);
//    tmp = 0;
//    max = 0;
//    for (int i = 0; i < count; i++)
//    {
//        if (arr[i] < max)
//        {
//            max = arr[i];
//        }
//    }
//    PrintMin(max);

//    tmp = 0;
//    for (int i = 0; i < count; i++)
//    {
//        tmp += arr[i];
//    }
//    PrintAvg(tmp/count);
//}

namespace RefactorClassesAndMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Printer
    {
        public void PrintStatistics(double[] statistics, int countOfElements)
        {
            double[] currentStatistics = statistics;
            int currentCount = countOfElements;

            double maxElement = this.FindMax(currentStatistics, currentCount);
            double minElement = this.FindMin(currentStatistics, currentCount);
            double sumOfElements = this.CalculateSum(currentStatistics, currentCount);
            double averageElementValue = sumOfElements / currentCount;

            this.Print(maxElement);
            this.Print(minElement);
            this.Print(averageElementValue);
        }

        private double FindMax(double[] arr, int count)
        {
            double currentMaxElement = 0;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > currentMaxElement)
                {
                    currentMaxElement = arr[i];
                }
            }

            return currentMaxElement;
        }

        private double FindMin(double[] arr, int count)
        {
            double currentMinElement = 0;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] < currentMinElement)
                {
                    currentMinElement = arr[i];
                }
            }

            return currentMinElement;
        }

        private double CalculateSum(double[] arr, int count)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        private void Print(double element)
        {
            Console.WriteLine(element);
        }
    }
}
