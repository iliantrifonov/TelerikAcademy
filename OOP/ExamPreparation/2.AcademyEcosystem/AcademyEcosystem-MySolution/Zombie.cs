using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieDefaultSize = 0;
        private const int ZombieMeatValue = 10;
        public Zombie(string name, Point location) : base(name, location, ZombieDefaultSize)
        {

        }

        public override int GetMeatFromKillQuantity()
        {
            return ZombieMeatValue;
        }
    }
}
