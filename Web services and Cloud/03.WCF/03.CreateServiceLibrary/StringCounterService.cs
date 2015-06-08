namespace _03.CreateServiceLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    public class StringCounterService : IStringCounterService
    {
        public int CountTimesFirstContainedInSecondString(string first, string second)
        {
            int index = second.IndexOf(first);
            int count = 0;
            while (index != -1)
            {
                count++;
                index = second.IndexOf(first, index + 1);
            }

            return count;
        }
    }
}
