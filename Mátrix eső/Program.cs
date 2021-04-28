using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mátrix_eső
{
    class Program
    {
        static int szamlalo;
        static Random rnd = new Random();

        static int aramlasi_sebesseg = 100;
        static int gyors_aramlas = aramlasi_sebesseg + 30;
        static int szovegaramlas = gyors_aramlas + 50;

        static ConsoleColor alapszin = ConsoleColor.DarkGreen;
        
        static ConsoleColor attunes_szin = ConsoleColor.White;

        static String utolso_szoveg = "I-D-E  B-Á-R-M-I-T  I-R-H-A-T-S-Z!!!!!!";

        static char AsciiKarakterek
        {
            get 
            {
                int t = rnd.Next(10);

                if          (t <= 2) return (char)('0' + rnd.Next(10));
                else if     (t <= 4) return (char)('a' + rnd.Next(27));
                else if     (t <= 6) return (char)('A' + rnd.Next(27));
                else return (char)(rnd.Next(32, 255));


            }
        }

        static void Main() 
        
        {
            Console.ForegroundColor = alapszin;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
            int szelesseg, magassag;
            int[] y;
            Inicializálás(out szelesseg, out magassag, out y);

            while (true)
            {
                szamlalo++;
                OszlopFrissites( szelesseg, magassag, y);
                if (szamlalo > (3 * aramlasi_sebesseg)) 
                    szamlalo = 0; 
            }
            
        }
        
        public static int YMezoPozicio(int yPozicio, int magassag)
        {
            if(yPozicio < 0)           return yPozicio + magassag;
            else if(yPozicio < magassag) return yPozicio;
            else                        return 0;
        }
        private static void Inicializálás(out int szelesseg, out int magassag, out int[] y)
        {
            magassag = Console.WindowHeight;
            szelesseg = Console.WindowWidth - 1;
            y = new int[szelesseg];
            Console.Clear();

            for (int x = 0; x < szelesseg; ++x) { y[x] = rnd.Next(magassag); } 
        }
        private static void OszlopFrissites(int szelesseg, int magassag, int[] y)
        {
            int x;
            if (szamlalo < aramlasi_sebesseg)
            {
                for (x = 0; x < szelesseg; ++x)
                {
                    if (x % 10 == 1) Console.ForegroundColor = attunes_szin;
                    else Console.ForegroundColor = alapszin;

                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(AsciiKarakterek);

                    if (x % 10 == 9) Console.ForegroundColor = alapszin;
                    else Console.ForegroundColor = alapszin;

                    int temp = y[x] - 2;
                    Console.SetCursorPosition(x, YMezoPozicio(temp, magassag));
                    Console.Write(AsciiKarakterek);

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, YMezoPozicio(temp1, magassag));
                    Console.Write(' ');
                    y[x] = YMezoPozicio(y[x] + 1, magassag);
                }

            }
            else if (szamlalo > aramlasi_sebesseg && szamlalo < gyors_aramlas)
            {
                for (x = 0; x < szelesseg; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    if (x % 10 == 9) Console.ForegroundColor = attunes_szin;
                    else Console.ForegroundColor = alapszin;

                    Console.WriteLine(AsciiKarakterek);

                    y[x] = YMezoPozicio(y[x] + 1, magassag);
                }
            }
            else if (szamlalo > gyors_aramlas)
            {
                for (x = 0; x < szelesseg; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(' ');

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, YMezoPozicio(temp1, magassag));
                    Console.Write(' ');

                    if (szamlalo > gyors_aramlas && szamlalo < szovegaramlas)
                    {
                        if (x % 10 == 9) Console.ForegroundColor = attunes_szin;
                        else                Console.ForegroundColor = alapszin;

                        int temp = y[x] - 2;
                        Console.SetCursorPosition(x,YMezoPozicio(temp, magassag));
                        Console.Write(AsciiKarakterek);
                    }

                    Console.SetCursorPosition(szelesseg / 2, magassag / 2);
                    Console.Write(utolso_szoveg);
                    y[x] = YMezoPozicio(y[x] + 1, magassag);
                }
            }
        }
    }
}
