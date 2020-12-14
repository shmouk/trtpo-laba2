﻿using System;
using System.Linq;
using OnlineRadio.Core;

namespace OnlineRadio.CommandLine
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 1)
            {
                switch (args[0])
                {
                    case "-url":
                        using (Radio radio = new Radio(args[1], false))
                        {
                            radio.OnCurrentSongChanged += (sender, eventArgs) =>
                                {
                                    Console.WriteLine(eventArgs.NewSong.Artist + " - " + eventArgs.NewSong.Title);
                                };

                            Radio.OnMessageLogged += (sender, eventArgs) =>
                            {
                                Console.WriteLine(eventArgs.Message);
                            };
                            radio.Start();
                            Console.ReadLine();
                            GC.KeepAlive(radio);
                        }
                        break;
                }
            }
        }
    }
}
