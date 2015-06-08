﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int DefaultLionSize = 6;
        public Lion(string name, Point location)
            : base(name, location, DefaultLionSize)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size * 2)
                {
                    this.Size += 1;
                    return animal.GetMeatFromKillQuantity();
                }
            }
            
            return 0;
        }
    }
}
