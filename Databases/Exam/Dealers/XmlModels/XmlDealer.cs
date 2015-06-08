namespace XmlModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class XmlDealer
    {
        public string Name { get; set; }

        public ICollection<XmlCity> Cities { get; set; }
    }
}
