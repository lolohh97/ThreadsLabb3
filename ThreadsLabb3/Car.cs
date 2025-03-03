﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadsLabb3
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public static void Race(Car obj)
        {
            Console.WriteLine(obj.Name + " started");
            bool Start = true;
            int sec = 0;
            while (Start)
            {
                for (int i = 0; i <= 50; i++)
                {
                    Console.WriteLine(obj.Name + " ----- " + i.ToString());
                    obj.Distance = obj.Distance - obj.Speed;
                    sec++;
                    Thread.Sleep(1000);
                    if (sec == 5)
                    {
                        Random re = new Random();
                        int num = re.Next(0, 50);

                        Thread.Sleep(500);
                        if (num == 1)
                        {
                            Console.WriteLine(obj.Name + " needs to refuel...");
                            Thread.Sleep(8000);
                            num = 0;
                        }
                        if (num == 2 && num == 3)
                        {
                            Console.WriteLine(obj.Name + " needs to change tires...");
                            Thread.Sleep(6000);
                            num = 0;
                        }
                        if (num >= 4 && num <= 8)
                        {
                            Console.WriteLine(obj.Name + " has birdpoop on it, oopsie...");
                            Thread.Sleep(4000);
                            num = 0;
                        }
                        if (num >= 9 && num <= 19)
                        {
                            Console.WriteLine(obj.Name + " engine failure, slowing down...");
                            Thread.Sleep(2000);
                            obj.Speed = obj.Speed - 1;
                            num = 0;
                        }
                        sec = 0;
                    }
                    if (obj.Speed == 0)
                    {
                        Console.WriteLine(obj.Name + " broke down henny...");
                        Start = false;
                        break;
                    }
                    if (i >= 50)
                    {
                        Console.WriteLine("GOOOOAAAAL! :D");
                        Console.WriteLine(obj.Name + " won! <3");
                        Environment.Exit(0);
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.S)
                        {
                            Console.WriteLine(obj.Name + " - Speed: " + obj.Speed + " Distance left: " + obj.Distance);
                        }
                    }
                }
            }
        }
    }
}
