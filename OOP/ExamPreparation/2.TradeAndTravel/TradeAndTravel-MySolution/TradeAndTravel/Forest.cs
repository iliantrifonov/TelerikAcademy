using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Forest : GatheringLocation
    {
        private const LocationType LocType = LocationType.Forest;
        private const ItemType GatheredItemType = ItemType.Wood;
        private const ItemType RequiredItemType = ItemType.Weapon;

        public Forest(string name) : base(name, LocType, GatheredItemType, RequiredItemType) { }
        public override Item ProduceItem(string name)
        {
            return new Wood(name);
        }
    }
}
