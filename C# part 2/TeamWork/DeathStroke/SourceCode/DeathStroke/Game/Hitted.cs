using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Hitted
    {
        public int scorePerHit {  get; private set; }
        public int crossHairX;
        public int crossHairY;
        public int hittedTargetIndex { get; private set; }


        public Hitted()
        {
            scorePerHit = 0;
            crossHairX = Console.WindowWidth / 2;
            crossHairY = Console.WindowHeight / 2;
            hittedTargetIndex = -1;
        }

        public Hitted(int positionX, int positionY) 
        {
            scorePerHit = 0;
            crossHairX = positionX;
            crossHairY = positionY;
            hittedTargetIndex = -1;
        }

        public Hitted(CrossHair crossHair, List<Targets> targetList)
        {
            hittedTargetIndex = -1;
            for (int i = 0; i < targetList.Count(); i++)
            {
                int Xcross = crossHair.positionX;
                int Ycross = crossHair.positionY;
                int Xtar = targetList[i].positionX;
                int Ytar = targetList[i].positionY;
                if (targetList[i] is Dog)
                {
                    //Body hit
                    if ((Xcross == Xtar && Ycross == Ytar) ||
                        (Xcross == Xtar + 1 && Ycross == Ytar))
                    {
                        scorePerHit = 50;
                    }
                    //Legs/arms hit
                    else if ((Xcross == Xtar && Ycross == Ytar + 1) ||
                        (Xcross == Xtar + 1 && Ycross == Ytar + 1))
                    {
                        scorePerHit = 25;
                    }
                    //Head hit
                    else if (Xcross == Xtar + 2 && Ycross == Ytar)
                    {
                        scorePerHit = 100;
                    }
                    //Dog's tail hit
                    else if (Xcross == Xtar - 1 && Ycross == Ytar)
                    {
                        scorePerHit = 10;
                    }
                    else
                    {
                        scorePerHit = 0;
                    }
                    //Sets index of hitted target
                    if (scorePerHit != 0)
                    {
                        hittedTargetIndex = i;
                        break;
                    }

                }
                else if (targetList[i] is Giraffe)
                {
                    //Body hit
                    if ((Xcross == Xtar && Ycross == Ytar) ||
                        (Xcross == Xtar - 1 && Ycross == Ytar) ||
                        (Xcross == Xtar + 1 && Ycross == Ytar) ||
                        (Xcross == Xtar + 2 && Ycross == Ytar - 1))
                    {
                        scorePerHit = 50;
                    }
                    //Legs/arms hit
                    else if ((Xcross == Xtar - 2 && Ycross == Ytar + 1) ||
                        (Xcross == Xtar - 1 && Ycross == Ytar + 1) ||
                        (Xcross == Xtar && Ycross == Ytar + 1) ||
                        (Xcross == Xtar + 1 && Ycross == Ytar + 1))
                    {
                        scorePerHit = 25;
                    }
                    //Head hit
                    else if (Xcross == Xtar + 3 && Ycross == Ytar - 2)
                    {
                        scorePerHit = 100;
                    }
                    else
                    {
                        scorePerHit = 0;
                    }
                    //Sets index of hitted target
                    if (scorePerHit != 0)
                    {
                        hittedTargetIndex = i;
                        break;
                    }
                }
                else if (targetList[i] is Human)
                {
                    //Body hit
                    if (Xcross == Xtar && Ycross == Ytar + 1)
                    {
                        scorePerHit = 50;
                    }
                    //Legs/arms hit
                    else if ((Xcross == Xtar - 1 && Ycross == Ytar + 1) ||
                        (Xcross == Xtar + 1 && Ycross == Ytar + 1) ||
                        (Xcross == Xtar - 1 && Ycross == Ytar + 2) ||
                        (Xcross == Xtar + 1 && Ycross == Ytar + 2))
                    {
                        scorePerHit = 25;
                    }
                    //Head hit
                    else if (Xcross == Xtar && Ycross == Ytar)
                    {
                        scorePerHit = 100;
                    }
                    else
                    {
                        scorePerHit = 0;
                    }
                    //Sets index of hitted target
                    if (scorePerHit != 0)
                    {
                        hittedTargetIndex = i;
                        break;
                    }
                }

                else
                {
                    scorePerHit = 0;
                }
            }
            //Remove hitted target
            if (hittedTargetIndex > -1 && hittedTargetIndex < Program.targetList.Count())
            {
                Program.targetList.RemoveAt(hittedTargetIndex);
            }
        }
    }
}
