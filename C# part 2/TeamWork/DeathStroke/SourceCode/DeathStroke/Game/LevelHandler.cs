using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    //TODO: Add more levels to the folder Levels( make sure to keep the naming the same way so the methods below work !)
    class LevelHandler
    {
        public static void InitializeLevel(int level)
        {
            string levelPath = @"../../Levels/Level" + level.ToString() + ".txt";
            
            using (StreamReader reader = new StreamReader(levelPath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] arrayOfKeyWords = SplitString(line);
                    if (arrayOfKeyWords[0] == "Dog")
                    {
                        int amountOfDogs = int.Parse(arrayOfKeyWords[1]);
                        for (int i = 0; i < amountOfDogs; i++)
                        {
                            line = reader.ReadLine();
                            int[] dogCoords = GetCoordinates(line);
                            Program.targetList.Add(new Dog(dogCoords[0], dogCoords[1]));
                        }
                    }
                    else if (arrayOfKeyWords[0] == "Giraffe")
                    {
                        int amountOfGiraffes = int.Parse(arrayOfKeyWords[1]);
                        for (int i = 0; i < amountOfGiraffes; i++)
                        {
                            line = reader.ReadLine();
                            int[] giraffeCoords = GetCoordinates(line);
                            Program.targetList.Add(new Giraffe(giraffeCoords[0], giraffeCoords[1]));
                        }
                    }
                    else if (arrayOfKeyWords[0] == "Human")
                    {
                        int amountOfHumans = int.Parse(arrayOfKeyWords[1]);
                        for (int i = 0; i < amountOfHumans; i++)
                        {
                            line = reader.ReadLine();
                            int[] humanCoords = GetCoordinates(line);
                            Program.targetList.Add(new Human(humanCoords[0], humanCoords[1]));
                        }
                    }
                    else if (arrayOfKeyWords[0] == "CloseTree")
                    {
                        int amountOfTrees = int.Parse(arrayOfKeyWords[1]);
                        for (int i = 0; i < amountOfTrees; i++)
                        {
                            line = reader.ReadLine();
                            int[] treeCoords = GetCoordinates(line);
                            Program.treeList.Add(new CloseTree(treeCoords[0], treeCoords[1]));
                        }
                    }
                    else if (arrayOfKeyWords[0] == "AwayTree")
                    {
                        int amountOfTrees = int.Parse(arrayOfKeyWords[1]);
                        for (int i = 0; i < amountOfTrees; i++)
                        {
                            line = reader.ReadLine();
                            int[] treeCoords = GetCoordinates(line);
                            Program.treeList.Add(new AwayTree(treeCoords[0], treeCoords[1]));
                        }
                    }
                    line = reader.ReadLine();
                }
            }
        }

        private static string[] SplitString(string line) 
        {
            string[] arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return arr;
        }

        private static int[] GetCoordinates(string line)
        {
            string[] arr = SplitString(line);
            int[] coordsArr = new int[arr.Length];
            for (int i = 0; i < coordsArr.Length; i++)
            {
                coordsArr[i] = int.Parse(arr[i]);
            }
            return coordsArr;
        }
    }
}
