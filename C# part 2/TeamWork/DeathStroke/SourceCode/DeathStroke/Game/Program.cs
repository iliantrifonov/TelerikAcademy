using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        public static List<Targets> targetList = new List<Targets>();
        public static List<Trees> treeList = new List<Trees>();

        public static CrossHair playerCrosshair = new CrossHair();

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 60;
            Menu a = new Menu();
            a.InitializeMenu();
            while (true)
            {
                Console.Clear();
                DrawItems.Draw();
                while (Console.KeyAvailable)
                {
                    Console.Clear();
                    DrawItems.Draw();
                    ConsoleKeyInfo key = Console.ReadKey();
                    
                    //TODO: Make this switch/case to make it run faster
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        playerCrosshair.MoveLeft();
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        playerCrosshair.MoveRight();
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        playerCrosshair.MoveUp();
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        playerCrosshair.MoveDown();
                    }
                    else if (key.Key == ConsoleKey.Spacebar)
                    {
                        GameSound.PlaySniper();
                        //TODO: Important ! Make a class Score that handles scores along with the Hitted class. Also make it draw the current score + time on the bottom right.
                        Hitted hit = new Hitted(playerCrosshair, targetList);
                        //TODO: Total score handler: The score should be points divided by time, so the faster you do it, the higher the score
                        //totalScore += hit.scorePerHit;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        a.InitializeMenu();
                    }

                    Thread.Sleep(50);
                }
            }
        }
    }
}
