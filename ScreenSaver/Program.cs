using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenSaver
{
    public static class Program
    {
        static void Main (string[] args)
        {
            ScreenSaver screenSaver = new ScreenSaver();
            //create thread object
            Thread screenSaverThread = new Thread(() => screenSaver.Start()); //lambda expression
            //start the thread
            screenSaverThread.Start();
            bool isScreenSaverRunning = true;
            while (isScreenSaverRunning)
            {
                //citim o cheie
                ConsoleKeyInfo cki = Console.ReadKey(true); //blocking
                isScreenSaverRunning = (cki.Key != ConsoleKey.N);
                if (!isScreenSaverRunning)
                {
                    screenSaver.Quit();
                    screenSaverThread.Join();
                }
            } 
        }
    }
}
