using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenSaver
{
    public class ScreenSaver
    {
        public ScreenSaver()
        {
            mIsRunning = true;
            mRandom = new Random(); //Random.Next nu e statica
            mColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        }

        public void Start()
        {
            while (mIsRunning) //atat timp cat e isRunning
            {
                //repozitioneaza bufferul(text) din consola
                Console.WindowTop = 0;
                Console.WindowLeft = 0;

                //select random position
                Console.SetCursorPosition(
                    //alege minim astfel incat pozitia sa fie intotdeauna pe ecran
                    mRandom.Next(Math.Min(Console.BufferWidth, Console.WindowWidth)),
                    mRandom.Next(Math.Min(Console.BufferHeight, Console.WindowHeight))
                    );
                //select random color
                Console.BackgroundColor = SelectRandomColor();
                Console.ForegroundColor = SelectRandomColor();
                //print
                Console.Write('o');
                //sleep
                Thread.Sleep(20); //setam viteza o data la 20 milisecunde
            }
        }

        public void Quit()
        {
            mIsRunning = false;
        }

        private ConsoleColor SelectRandomColor()
        {
            return mColors[mRandom.Next(mColors.Length)];
        }

        private bool mIsRunning;
        private Random mRandom;
        private ConsoleColor[] mColors;
    }
}
