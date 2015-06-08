using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceProcess;

namespace Game
{
    class Menu
    {
        private int x;
        private int y;
        private int indexOfMenu;
        private string nameOfPlayer = "Hunter";
        private List<string> highScores = new List<string>();

        //TODO: Make a menu stub for Scores
        private string[] menuItems = { "New game", "Continue", "Change Name", "High Scores", "Credits", "Exit" };

        public Menu()
        {
            this.x = Console.WindowWidth / 2 - 4;
            this.y = Console.WindowHeight / 2;
            this.indexOfMenu = 0;
        }

        //Read score from file, each score should have "nameOfPlayer score" in the text file.
        private void ReadScoreFromFile()
        {
            using (StreamReader reader = new StreamReader(@"..\..\HighScores.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    highScores.Add(line);
                    line = reader.ReadLine();
                }
            }
            
        }

        private void WriteScoreToFile()
        {
            //TODO: Write score to file, each score should have "nameOfPlayer score" in the text file.
        }

        public void InitializeMenu()
        {
            ReadScoreFromFile();
            try
            {
               GameSound.PlayMenuSound();
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Sound file format is incorrect");
                Thread.Sleep(1000);
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                Console.WriteLine("Could not retrieve sound file");
                Thread.Sleep(1000);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Sound file missing");
                Thread.Sleep(1000);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Error playing sound file");
                Thread.Sleep(1000);
            }
            
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
                    switch (menuItems[indexOfMenu])
                    {
                        //TODO: Add menu stub here to choose from levels, make a draw method similar to DrawMenu, but working on a different list
                        case "New game":
                            //TODO: Important, make exception handling for the LevelHandler Class!
                            try
                            {
                                LevelHandler.InitializeLevel(1);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Could not access the level file");
                                Thread.Sleep(1000);
                                InitializeMenu();
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("Directory of level file not found");
                                Thread.Sleep(1000);
                                InitializeMenu();
                            }
                            catch (FileNotFoundException)
                            {
                                Console.WriteLine("Level file not found");
                                Thread.Sleep(1000);
                                InitializeMenu();
                            }
                            catch (IOException)
                            {
                                Console.WriteLine("Could not access the level file");
                                Thread.Sleep(1000);
                                InitializeMenu();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Could not access the level file, or it is corrupted");
                                Thread.Sleep(1000);
                                InitializeMenu();
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Overflow while accessing level file");
                                Thread.Sleep(1000);
                                InitializeMenu();
                            } 
                            Console.Clear();
                            GameSound.StopMenuSound();
                            return;
                        case "Continue":
                            Console.Clear();
                            GameSound.StopMenuSound();
                            return;
                        case "Exit":
                            Console.Clear();
                            WriteScoreToFile();
                            Environment.Exit(0);
                            break;
                        case "Change Name":
                            ChangeName();
                            break;
                        case "Credits":
                            PrintCredits();
                            break;
                        case "High Scores":
                            PrintHighScores();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void PrintCredits()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            int padding = 30;
            string[] credits = new string[] { String.Format("Ilian Trifonov").PadRight(padding),
                                              String.Format("Nickname:"+ String.Format("iliantrifonov").PadLeft(15)).PadLeft(padding),
                                              Environment.NewLine,
                                              String.Format("Stanimir Ivanov").PadRight(padding),
                                              String.Format("Nickname:"+ String.Format("stanimir1990").PadLeft(15)).PadLeft(padding),
                                              Environment.NewLine,
                                              String.Format("Veliko Velichkov").PadRight(padding),
                                              String.Format("Nickname:"+ String.Format("veliko").PadLeft(15)).PadLeft(padding),
                                              Environment.NewLine,
                                              String.Format("Hristo Panayotov").PadRight(padding),
                                              String.Format("Nickname:"+ String.Format("bassta").PadLeft(15)).PadLeft(padding), 
                                              Environment.NewLine,
                                              String.Format("Nikolay Karachorov").PadRight(padding),
                                              String.Format("Nickname:"+ String.Format("specnaz").PadLeft(15)).PadLeft(padding), 
                                              Environment.NewLine,
                                              String.Format("Alexander Nenovski").PadRight(padding),
                                              String.Format("Nickname:"+ String.Format("DigBicks").PadLeft(15)).PadLeft(padding),};
            for (int i = -(credits.Length/2); i <= credits.Length/2; i++)
            {
                Console.SetCursorPosition(x - padding/2, y + i);
                Console.WriteLine(credits[i + credits.Length/2]);
            }
            Console.ReadLine();
        }

        private void ChangeName ()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y - this.indexOfMenu);
            Console.WriteLine("Enter new name:");
            Console.SetCursorPosition(x, y - this.indexOfMenu + 2);
            Console.ForegroundColor = ConsoleColor.White;
            string name = Console.ReadLine().Replace(' ', new Char());
            nameOfPlayer = name;
        }

        private void PrintHighScores()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y - 6);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("High Scores:");
            Console.ForegroundColor = ConsoleColor.White;
            char[] separators = new char[]{' '};
            for (int i = 0; i < 10 && i < highScores.Count(); i++)
            {
                string[] arr = highScores[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Console.SetCursorPosition(x, y - 6 + 2 + i);
                Console.WriteLine(arr[0].PadRight(12) + arr[1].PadLeft(5));
            }
            Console.ReadLine();
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
