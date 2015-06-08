namespace WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    using Model;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAlertsService
    {
        [WebGet(UriTemplate = "api/alerts")]
        [OperationContract]
        IEnumerable<AlertModel> GetAlerts();

        //[WebInvoke(Method = "POST", UriTemplate = "")]
        //[WebGet(UriTemplate="")]

        // TODO: Add your service operations here
    }
}
