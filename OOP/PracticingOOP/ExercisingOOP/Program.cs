namespace ExercisingOOP
{
    class Program
    {
        static void Main()
        {
            GSM firstGsm = new GSM();
            Battery firstBattery = new Battery("MHD100", BatteryType.LiIon , 70, 10);
            firstGsm.Model = "XperiaS";
            firstGsm.Manufacturer = "SONY";
            firstGsm.Owner = "Me";
            firstGsm.Price = 500;   


     
            firstGsm.GetGsmInfo(firstGsm);
           
        }
    }
}
