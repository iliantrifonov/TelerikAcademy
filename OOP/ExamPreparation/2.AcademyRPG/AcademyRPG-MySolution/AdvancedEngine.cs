﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class AdvancedEngine : Engine
    {
        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                case "ninja":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }
                case "giant":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Giant(name, position));
                        break;
                    }
                case "house":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }
                case "rock":
                    {

                        int hitPoints = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(position, hitPoints));
                        break;
                    }
                default:
                    base.ExecuteCreateObjectCommand(commandWords);
                    break;
            }
        }

        public override void ExecuteControllableCommand(string[] commandWords)
        {
            base.ExecuteControllableCommand(commandWords);
        }
    }
}