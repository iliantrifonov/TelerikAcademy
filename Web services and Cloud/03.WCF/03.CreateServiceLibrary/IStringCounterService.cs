namespace _03.CreateServiceLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    [ServiceContract]
    public interface IStringCounterService
    {
        [OperationContract]
        int CountTimesFirstContainedInSecondString(string first, string second);
    }
}
