namespace WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    [DataContract]
    public class AlertModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}