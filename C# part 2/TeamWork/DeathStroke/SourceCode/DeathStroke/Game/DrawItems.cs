using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DrawItems
    {
        public static void Draw()
        {
            for (int i = 0; i < Program.targetList.Count; i++)
            {
                Program.targetList[i].Draw();
            }
            for (int i = 0; i < Program.treeList.Count; i++)
            {
                Program.treeList[i].Draw();
            }
            Program.playerCrosshair.Draw();
        }
    }
}
