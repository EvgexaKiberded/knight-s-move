using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Vlad_AISD
{
    class Program
    {
        public const string CppFunctionDll = @"Обход_конём.dll";
        [DllImport(CppFunctionDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Move([In, Out] int[,] daske, int a, int b);
        static void Main(string[] args)
        {
            const int N = 8;
            int[,] daske = new int[N, N];
            Console.WriteLine("   1 2 3 4 5 6 7 8");
            Console.Write("  +----------------+");
            char ch = 'A';
            for (int i = 0; i < N; i++)
            {
                Console.Write($"\n{(ch).ToString()} |");
                for (int j = 0; j < N; j++)
                {
                    if ((i+j) % 2 == 0)
                        Console.Write("* ");
                    else
                        Console.Write("  ");
                }
                Console.Write($"| {(ch++).ToString()}");
            }
            Console.WriteLine("\n  +----------------+");
            Console.WriteLine("   1 2 3 4 5 6 7 8");
            while (true)
            {
                Console.WriteLine($"\n\nВведите положение коня(букву):");
                ConsoleKeyInfo ach = Console.ReadKey();
                Console.WriteLine();
                if (ach.KeyChar < 'a' || ach.KeyChar > 'h')
                    {                
                    Console.WriteLine("Некорректное значение!");
                    continue;
                }
                
                int a = ((int)ach.KeyChar) - 97 ;
                Console.WriteLine($"Введите положение коня(цифру):");
                int b = int.Parse(Console.ReadLine())-1;
                if (b > 8 || b < 0)
                {
                    Console.WriteLine("Некорректное значение!");
                    continue;
                }

                Console.WriteLine("Путь коня по доске - шаги от начала (1) до конца  (64):");
                Move(daske, a, b); ;
                Console.Write("\n  ");

                for (int i = 1; i < N+1; i++)
                {
                    Console.Write("{0,5}", i);
                }

                Console.WriteLine();
                Console.Write("  +------------------------------------------+\n  |");
                Console.WriteLine("{0,43}", "|");
                ch = 'A';
                for (int i = 0; i < N; i++)
                {
                    Console.Write($"{(ch).ToString()} |");
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write("{0,5}", daske[i,j]  );
                    }
                    Console.Write($"  |{(ch++).ToString()} \n ");
                    Console.Write(" |");
                    Console.WriteLine("{0,43}", "|");

                }
                Console.Write("  +------------------------------------------+\n  ");
                for (int i = 1; i < N + 1; i++)
                {
                    Console.Write("{0,5}", i);
                }
                Console.WriteLine();
            }
        }
    }
}
