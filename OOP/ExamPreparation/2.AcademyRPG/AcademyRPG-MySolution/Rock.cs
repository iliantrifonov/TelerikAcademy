using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        private int quantity;

        public Rock( Point position, int hitPoints)
            : base(position)
        {
            this.HitPoints = hitPoints;
            this.Quantity = this.HitPoints / 2;
        }

        public int Quantity { get; protected set; }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }
    }
}
