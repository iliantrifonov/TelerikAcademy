using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Menu
    {
        private int x;
        private int y;
        private int indexOfMenu;
        private string[] menuItems = { "New game", "Continue", "Exit" };

        public Menu()
        {
            this.x = Console.WindowWidth / 2 - 4;
            this.y = Console.WindowHeight / 2;
            this.indexOfMenu = 0;
        }

        private void ReadScoreFromFile()
        {
            //TODO: Read score from file
        }

        private void WriteScoreToFile()
        {
            //TODO: Write score to file
        }

        public void InitializeMenu()
        {
            ReadScoreFromFile();
            
            while (true)
            {
                Console.Clear();
                DrawMenu();
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    indexOfMenu++;
                    if (indexOfMenu >= this.menuItems.Length)
                    {
                        indexOfMenu = this.menuItems.Length - 1;
                    }
                    DrawMenu();
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    indexOfMenu--;
                    if (indexOfMenu < 0)
                    {
                        indexOfMenu = 0;
                    }
                    DrawMenu();
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    switch (indexOfMenu)
                    {
                        case 0:
                            Console.Clear();
                            return;
                        case 1:
                            Console.Clear();
                            return;
                        case 2:
                            Console.Clear();
                            WriteScoreToFile();
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void DrawMenu(ConsoleColor color = ConsoleColor.DarkBlue)
        {
            Console.ForegroundColor = color;
            int tempY = y;
            for (int i = 0; i < this.menuItems.Length ; i++)
            {
                
                if (i == indexOfMenu)
                {
                    tempY++;
                    Console.SetCursorPosition(x, tempY - this.indexOfMenu);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuItems[i]);
                    tempY++;
                    Console.ForegroundColor = color;
                }
                else
                {
                    Console.SetCursorPosition(x, tempY - this.indexOfMenu);
                    Console.WriteLine(menuItems[i]);
                }
                tempY++;
            }
        }
    }
}
