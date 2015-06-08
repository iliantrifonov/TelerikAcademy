using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, LocationType locationType, ItemType gathered, ItemType required)
            : base(name, locationType)
        {
            this.GatheredType = gathered;
            this.RequiredItem = required;
        }
        public ItemType GatheredType { get; protected set; }

        public ItemType RequiredItem { get; protected set; }

        public abstract Item ProduceItem(string name);
    }
}
