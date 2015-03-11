namespace MobilePhones
{
    using System;

    public class GSMTest
    {
        private const decimal PricePerMin = 0.37m;

        public static void Main()
        {
            GSM[] fewGsms = new GSM[5];
            Random random = new Random();

            for (int i = 0; i < fewGsms.Length; i++)
            {
                BatteryType type = (BatteryType)i;
                Battery someBattery = new Battery("CE" + random.Next(1000, 5000), random.Next(50, 100), random.Next(20, 40), type);
                Display someDisplay = new Display(string.Format("{0} inches", random.Next(5, 10)), 16000000);
                fewGsms[i] = new GSM(string.Format("Xperia{0}", (char)85 + i), "Sony", random.Next(500, 1500), "Malkovski", someBattery, someDisplay);
            }

            for (int i = 0; i < fewGsms.Length; i++)
            {
                Console.WriteLine(fewGsms[i]);
            }

            Console.WriteLine(GSM.IPhoneS4);

            Battery myBattery = new Battery("CE1000", 100, 100, BatteryType.Nuclear);
            Display myDisplay = new Display("10 inches", 99000000);
            GSM myPhone = new GSM("XperiaS", "Sony", 500, "Me", myBattery, myDisplay);

            for (int i = 0; i < 10; i++)
            {
                DateTime date = DateTime.Now;
                Call oneCall = new Call(date, date, (random.Next(888000000, 888999999).ToString()), random.Next(1, 100));
                myPhone.AddCall(oneCall);
            }

            foreach (var calls in myPhone.CallHistory)
            {
                Console.WriteLine(calls);
            }

            Console.WriteLine("Total cost: {0:0.00}", myPhone.CostCalculation(PricePerMin));

            int maxDuartion = 0;
            Call longest = myPhone.CallHistory[0];

            for (int i = 0; i < myPhone.CallHistory.Count; i++)
            {
                if (myPhone.CallHistory[i].Duration > maxDuartion)
                {
                    maxDuartion = myPhone.CallHistory[i].Duration;
                    longest = myPhone.CallHistory[i];
                }
            }

            myPhone.DelCall(longest);
            Console.WriteLine("New total cost: {0:0.00}", myPhone.CostCalculation(PricePerMin));
            myPhone.DeleteHistory();

            foreach (var call in myPhone.CallHistory)
            {
                Console.WriteLine(call);
            }        
        }
    }
}
