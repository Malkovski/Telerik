namespace CompanySampleDataImporter.Importer.RandomGenerators
{
    using System;
    using System.Linq;
    using System.Text;

    public class RandomGenerator
    {
        private readonly Random random = new Random();

        private const string AlphaNumerics = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        public string RandomString(int minLen, int maxLen)
        {
            var sb = new StringBuilder();

            int currentLen = this.RandomNumber(minLen, maxLen);

            for (int i = 0; i < currentLen; i++)
            {
                int currentIndex = this.random.Next(0, AlphaNumerics.Length);
                sb.Append(AlphaNumerics[currentIndex]);
            }

            return sb.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public DateTime RandomDate(DateTime? after = null, DateTime? before = null)
        {
            DateTime minDate = after ?? new DateTime(1980, 1, 1, 0, 0, 0);
            DateTime maxDate = after ?? new DateTime(2050, 12, 31, 23, 59, 59);

            int second = this.RandomNumber(minDate.Second, maxDate.Second);
            int minute = this.RandomNumber(minDate.Minute, maxDate.Minute);
            int hour = this.RandomNumber(minDate.Hour, maxDate.Hour);
            int day = this.RandomNumber(minDate.Day, maxDate.Day);
            int month = this.RandomNumber(minDate.Month, maxDate.Month);
            int year = this.RandomNumber(minDate.Year, maxDate.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}