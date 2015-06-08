namespace _01.GSMExercise
{
    using System;
    //7.Write a class GSMTest to test the GSM class:
    //Create an array of few instances of the GSM class.
    //Display the information about the GSMs in the array.
    //Display the information about the static property IPhone4S.

    class GSMTest
    {
        public static void TestGSM()
        {
            GSM.IPhone4S = new GSM("IPhone 4S", "Apple");
            GSM[] arrayOfPhones = new GSM[3];
            arrayOfPhones[0] = new GSM("S4", "Samsung", "Some guy", 999, new Battery("Some battery model", 300, 100, BatteryType.LiIon), new Display("1980x1080", 11213312464));
            arrayOfPhones[1] = GSM.IPhone4S;
            arrayOfPhones[2] = new GSM("300GT", "LG", "A cat owner");
            Console.WriteLine("Information about the phones in the array");
            foreach (var item in arrayOfPhones)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Information about the IPhone:");
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
