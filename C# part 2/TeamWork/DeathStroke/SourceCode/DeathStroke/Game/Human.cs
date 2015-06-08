using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Human : Targets
    {
        public Human(int x, int y) : base(x, y) { }

        public override void Draw()
        {
            Console.SetCursorPosition(this.positionX, this.positionY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine('O');
            Console.SetCursorPosition(this.positionX - 1, this.positionY + 1);
            Console.Write('-');
            Console.SetCursorPosition(this.positionX, this.positionY + 1);
            Console.Write('|');
            Console.SetCursorPosition(this.positionX + 1, this.positionY + 1);
            Console.WriteLine('-');
            Console.SetCursorPosition(this.positionX - 1, this.positionY + 2);
            Console.WriteLine('/');
            Console.SetCursorPosition(this.positionX + 1, this.positionY + 2);
            Console.WriteLine('\\');
        }
    }
}
