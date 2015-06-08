namespace _01.GSMExercise
{
    using System;
    //12.Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
    //Create an instance of the GSM class.
    //Add few calls.
    //Display the information about the calls.
    //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
    //Remove the longest call from the history and calculate the total price again.
    //Finally clear the call history and print it.

    class GSMCallHistoryTest
    {
        public static void TestCallHistory()
        {
            GSM phone = new GSM("S4", "samsung");
            GSM.pricePerMinute = (decimal)0.37;
            phone.AddCall(new Call(DateTime.Now, 600, "0885 555 555"));
            phone.AddCall(new Call(DateTime.Now, 120, "0885 666 555"));
            phone.AddCall(new Call(DateTime.Now, 60, "0885 777 555"));
            Console.WriteLine("Call information:");
            foreach (var item in phone.CallHistory)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Price of the calls:");
            Console.WriteLine(phone.CalculatePriceOfCalls());
            phone.DeleteCall(0);

            Console.WriteLine("Price of the calls after removing the longest call:");
            Console.WriteLine(phone.CalculatePriceOfCalls());
            Console.WriteLine("Clearing call history");
            phone.ClearCallHistory();
            Console.WriteLine("Call information:");
            foreach (var item in phone.CallHistory)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
