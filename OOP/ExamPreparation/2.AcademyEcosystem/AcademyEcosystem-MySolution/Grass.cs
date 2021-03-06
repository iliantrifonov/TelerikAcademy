﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int GrassDefaultSize = 2;
        public Grass(Point location)
            : base(location, GrassDefaultSize)
        {

        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
            base.Update(time);
        }
    }
}
