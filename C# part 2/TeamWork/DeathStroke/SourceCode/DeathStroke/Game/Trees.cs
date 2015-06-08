using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Trees
    {
        public int positionX { get; private set; }
        public int positionY { get; private set; }

        public Trees(int x, int y)
        {
            this.positionX = x;
            this.positionY = y;
        }

        public virtual void Draw() { }
        //public void CloseTree()
        //{
        //    Console.SetCursorPosition(this.positionX, this.positionY);
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 3, this.positionY);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 3, this.positionY);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY - 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY - 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY - 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY - 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY - 1);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY - 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY - 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY - 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY - 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY - 2);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY - 3);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY - 3);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY - 3);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY - 4);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY + 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY + 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 1);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY + 1);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY + 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY + 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 2);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY + 2);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY + 3);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 3);
        //    Console.Write('*');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 3);
        //    Console.Write('*');
        //    //
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 4);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 4);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 5);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 5);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 6);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 6);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 7);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX, this.positionY + 7);
        //    Console.Write('_');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 7);
        //    Console.Write('|');
   
        //}
        //public void AwayTree()
        //{
        //    Console.SetCursorPosition(this.positionX, this.positionY);
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine('|');
        //    Console.SetCursorPosition(this.positionX-1, this.positionY);
        //    Console.Write('@');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY);
        //    Console.Write('@');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY);
        //    Console.Write('@');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY);
        //    Console.Write('@');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY-1);
        //    Console.WriteLine('|');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY-1);
        //    Console.Write('@');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY-1);
        //    Console.Write('@');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY - 2);
        //    Console.Write('@');
        //    //
        //    Console.SetCursorPosition(this.positionX, this.positionY + 1);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX, this.positionY + 2);
        //    Console.Write('|');

        //}
    }
}
