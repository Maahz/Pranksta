using System;
using System.Threading;
using System.Windows.Forms;

namespace Pranksta
{
    public static class Setup
    {
        public const int SPEED_CAP = 10;
        public const double MULTIPLR_INCR = .05;
        public static double multiplier = 1.0;
    }

    class Program
    {

        

        static void Main(string[] args)
        {
            Thread pranka = new Thread(new ThreadStart(PrankMe));
            pranka.Start();
            Console.ReadLine();
            pranka.Abort();
        }

        private static void PrankMe()
        {
            //What to write
            char[] key = {'C','o','m','e',' ','t','o',' ','m', 'e','!'};

            int i = 0;
            int loopCount = 0;

            Random rand = new Random();

            while (true)
            {

                loopCount++;
                if (loopCount >= 500)
                {
                    Berserk.Go();   //If you wait long enough, ghost will go berserk!
                    Thread.Sleep(1000);
                }
                else
                {


                    //Avoid out of bounds
                    try
                    {
                        //SendKeys.SendWait(key[i].ToString());
                        Console.Write(key[i].ToString());

                        //If multiplier is less than three, you can increase it
                        if (Setup.multiplier < Setup.SPEED_CAP)
                        {
                            Setup.multiplier = Setup.multiplier + Setup.MULTIPLR_INCR;   //Increase type speed every cycle
                        }
                        i++;
                    }
                    catch (Exception)
                    {
                        Console.Write("\n");    //Create new line at the end
                        i = 0;
                    }

                    Thread.Sleep(rand.Next(100, 500) / (int)Setup.multiplier);  //Unfortunately Thread.Sleep cant take decimals
                }
            }
        }
    }
}
