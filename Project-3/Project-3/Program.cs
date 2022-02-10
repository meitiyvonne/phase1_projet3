using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project_3
{
    class Program
    {
        int[] x = new int[5];
        int idx = 0;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartLottery();
        }

        private void StartLottery()
        {
            ShowMenu();
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("******** Bienvenue dans le jeu Lotterie Cookie ********");
            Console.WriteLine("*******************************************************\n\n");

            Console.WriteLine("*** Veuillez saisir vos 5 numbres en 1 et 200 ***");

            GetUserInput();

        }
        
        private bool VerifyUserInput(string s)
        {
            bool b;
            b = s.All(Char.IsDigit);
            if(!b)
            {
                ShowErrorMsg();
                GetUserInput();
            }
            int num = int.Parse(s);
            CheckRange(num);

            return b;
        }

        private bool CheckRange(int num)
        {
            bool b = true;
            if(!(num >=1 && num <=200))
            {
                b = false;
                ShowErrorMsg();
                GetUserInput();
            }
            return b;
        }

        private void GetUserInput()
        {
            int num;
            bool b;
            string s;
            
            while(idx < x.Length)
            {
                ShowMsg();
                s = Console.ReadLine();
                b = VerifyUserInput(s);
                if(b)
                {
                    num = int.Parse(s);
                    x[idx] = num;
                    idx++;
                }
            }
            PickNumber(x);
        }
        private void PickNumber(int[] x)
        {

            //List<int> result = ListPc(x);
            ListPc(x);
            //List<int> bingo = SaisirNum(x, result);
            //ShowResult(bingo);
            //PlayAgain();
            
            
        }


        private void ListPc(int[] x)
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int n = 0;
                do
                {
                    n = rnd.Next(1, 201);
                } while (numbers.Contains(n));

                numbers.Add(n);
            }
            SaisirNum(x, numbers);
            //return numbers;

        }

        private void SaisirNum(int[] x, List<int> n)
        {
            List<int> bingo = new List<int>();
            for (int i = 0; i < x.Length; i++)
            {
                if (n.Contains(x[i]))
                {
                    bingo.Add(x[i]);
                }
            }
            ShowResult(bingo);
            //return bingo;
        }
        private void ShowResult(List<int> bingo)
        {
            Console.WriteLine("\n************ Résultat ***********\n");
            Console.WriteLine($"Vous avez obtenu les {bingo.Count} numéros suivants:");
            foreach (var lottery in bingo)
            {
                {
                    Console.WriteLine(lottery);
                }
            }
            PlayAgain();
        }

        private void PlayAgain()
        {
            string yn;
            do
            {
                Console.WriteLine("Voulez-vous encore jouer (O/N)");
                yn = Console.ReadLine();

            } while (!(yn.Equals("o") || yn.Equals("O") || yn.Equals("n") || yn.Equals("N")));
            if (yn.Equals("o") || yn.Equals("O"))
            {
                
                EmptyLotteryArray();
                ShowMenu();
            }
            else if (yn.Equals("n") || yn.Equals("N"))
            {
                Console.Clear();
                Console.WriteLine("Au revoir!");
                System.Environment.Exit(0);

            }
        }

        private void EmptyLotteryArray()
        {
            Array.Clear(x,0,x.Length);
            idx = 0;
        }


        private void ShowMsg()
        {
            Console.WriteLine("Entrer un nombre et appuyer sur enter:");
        }
        private void ShowErrorMsg()
        {
            Console.WriteLine(" Veuillez entrer un nombre compris entre 1 et 200 seulement ");
        }
    }
}
