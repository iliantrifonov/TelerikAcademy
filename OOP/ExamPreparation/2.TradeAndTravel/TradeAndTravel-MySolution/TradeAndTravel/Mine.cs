using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Mine : GatheringLocation
    {
        private const LocationType LocType = LocationType.Mine;
        private const ItemType GatheredItemType = ItemType.Iron;
        private const ItemType RequiredItemType = ItemType.Armor;

        public Mine(string name) : base(name, LocType, GatheredItemType, RequiredItemType) { }
        public override Item ProduceItem(string name)
        {
            return new Iron(name);
        }
    }
}
