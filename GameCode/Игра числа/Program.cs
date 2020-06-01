using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра_числа
{
    class Program
    {
        public static int numofwin = 0;
        public static int numoflose = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(Instruction());
            StartGame();
            Console.ReadKey();

        }

        public static string Instruction()
        {
            string text = "Программа формирует четырехзначное число. Каждая цифра данного числа находится в диапазоне от 0 до 9." + '\n' +
                 "Цифры не повторяются. Ваша задача  с 7 попыток угадать загаданное число." + '\n' +
                 "Условные обозначение:" + '\n' +
                 "1)«+»-обозначает то, что Вы угадали цифру." + '\n' +
                 "2)«!»-обозначает то, что Вы угадали цифру и ее позицию." + '\n' +
                 "3)«нет совпадений»-обозначает то, что Вы не угадали цифры." + '\n' +
                 "Давайте начнем :";

            return text;
        }
        public static string CreatNum()

        {
            HashSet<int> a = new HashSet<int>();
            a.Clear();
            var rand = new Random();
            var arr = new int[4];
            for (int i = 0; i < arr.Length; i++)
            {
                int b;
                do
                {
                    b = rand.Next(0, 9);
                }
                while (!a.Add(b));

            }
            int[] c = new int[4];
            a.CopyTo(c);
            return String.Join(null, c);
        }
        public static string ChekNum(string rand, string chislo)
        {
            string ans = null;
            int n = 0;
            int p = 0;
            for (int i = 0; i < chislo.Length; i++)
            {
                for (int j = 0; j < rand.Length; j++)
                {
                    if (i == j && chislo[i] == rand[j])
                        p++;
                    else if (chislo[i] == rand[j])
                        n++;

                }
            }
            if (n == 0 && p == 0)
                return "нет совпадений";
            for (; p > 0; p--)
                ans += "!";
            for (; n > 0; n--)
                ans += "+";
            return ans;

        }
        public static string ChekIn(int m)
        {
            string chislo = null;
            {
                do
                {
                    Console.WriteLine("Введите 4 неповторяющихся цифры");
                    Console.Write(m + ")");
                    chislo = Console.ReadLine();
                }

                while (chislo.Length != 4 || !int.TryParse(chislo, out int k)) ;
                return chislo;
            }
           
        }
        public static void StartGame()
        {   
            string tmp = CreatNum();
            string chislo = null;
            string win = null;
            for(int i = 1; i<=7; i++)
            {
            chislo = ChekIn(i);
            win = ChekNum(tmp, chislo);
                if (win == "!!!!")
                    EndGame(true);

            Console.WriteLine(win);
            }
            EndGame(false);

        }
        public static void EndGame(bool chekwin)
        {
            if (chekwin)
            {
                numofwin++;
                Console.WriteLine("Вы выиграли!");

            }
            else
            {
                numoflose++;
                Console.WriteLine("Вы проиграли!");
            }
            Console.WriteLine("Вы выиграли {0} раз.Вы проиграли {1} раз. Хотите сыграть ещё?", numofwin, numoflose);

            switch (Console.ReadLine().ToLower())
            {
               
                case "да":
                  StartGame();
                    break;

                default:
                    Console.WriteLine("Нажмите любую клавишу, чтобы выйти");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
        }
        }
    }
  


