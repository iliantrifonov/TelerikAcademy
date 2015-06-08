using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Targets
    {
        public int positionX { get; private set; }
        public int positionY { get; private set; }

        public Targets(int x, int y)
        {
            this.positionX = x;
            this.positionY = y;
        }

        public virtual void Draw () { }

        //public void DrawMan()
        //{
        //    Console.SetCursorPosition(this.positionX, this.positionY);
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine('O');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 1);
        //    Console.Write('-');
        //    Console.SetCursorPosition(this.positionX, this.positionY + 1);
        //    Console.Write('|');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY +1);
        //    Console.WriteLine('-');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 2);
        //    Console.WriteLine('/');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 2);
        //    Console.WriteLine('\\');
        //}
        //public void DrawDog()
        //{
        //    Console.SetCursorPosition(this.positionX, this.positionY);
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.Write('_');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY);
        //    Console.Write('\\');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY);
        //    Console.Write('_');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY);
        //    Console.Write('@');
        //    Console.SetCursorPosition(this.positionX, this.positionY + 1);
        //    Console.Write('/');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 1);
        //    Console.Write('\\');
        //}
        //public void DrawGiraffe()
        //{
        //    Console.SetCursorPosition(this.positionX, this.positionY);
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.Write('_');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY);
        //    Console.Write('_');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY);
        //    Console.Write('/');
        //    Console.SetCursorPosition(this.positionX + 2, this.positionY - 1);
        //    Console.Write('/');
        //    Console.SetCursorPosition(this.positionX + 3, this.positionY - 2);
        //    Console.Write('@');
        //    Console.SetCursorPosition(this.positionX - 2, this.positionY + 1);
        //    Console.Write('/');
        //    Console.SetCursorPosition(this.positionX - 1, this.positionY + 1);
        //    Console.Write('\\');
        //    Console.SetCursorPosition(this.positionX, this.positionY + 1);
        //    Console.Write('/');
        //    Console.SetCursorPosition(this.positionX + 1, this.positionY + 1);
        //    Console.Write('\\');

 
        //}

    }
}
