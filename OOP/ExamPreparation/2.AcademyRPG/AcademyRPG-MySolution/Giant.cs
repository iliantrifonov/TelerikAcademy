using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int GiantOwner = 0;
        private bool gatheredStone;
        public Giant(string name, Point position) : base(name,position, GiantOwner)
        {
            this.HitPoints = 200;
            gatheredStone = false;
        }
        public int AttackPoints
        {
            get { return gatheredStone ? 250 : 150; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.gatheredStone = true;
                return true;
            }

            return false;
        }
    }
}
