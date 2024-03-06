// Read user input and print if it is even or odd
using System;

namespace Exercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 4: Choose an option:");
            Console.WriteLine("  1. Write even or odd on the screen, from a typed value");
            Console.WriteLine("  2. Find the maximum value between two numbers");
            Console.Write("  > ");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 2){
                Console.WriteLine("Invalid option, try again:");
                Console.Write("  > ");
            }

            if (option == 1){
                OddOrEven();
            } else {
                MaxValue();
}
        }

        static void OddOrEven(){
            int number;
            Console.WriteLine("Enter a number:");
            while (!int.TryParse(Console.ReadLine(), out number)){
                Console.WriteLine("Invalid number, try again:");
            }

            // 1. Escrever par ou ímpar na tela, a partir de uma variável:
            // a) com switch
            Console.WriteLine("\nUsing switch:");
            switch (number % 2){
                case 0:
                    Console.WriteLine("Even");
                    break;
                case 1:
                    Console.WriteLine("Odd");
                    break;
            }

            // b) com if sem else
            Console.WriteLine("\nUsing if without else:");
            if (number % 2 == 0){
                Console.WriteLine("Even");
            }
            if (number % 2 == 1){
                Console.WriteLine("Odd");
            }

            // c) sem nenhuma estrutura de controle
            Console.WriteLine("\nWithout control structure:");
            // This abomination is Luiz Freitas's fault, not mine, but it's technically correct
            string[] results = new string[2]{"Even", "Odd"};
            Console.WriteLine(results[number % 2]);

            // d) com operador ternário
            Console.WriteLine("\nUsing ternary operator:");
            Console.WriteLine((number % 2 == 0) ? "Even" : "Odd");
        }


        public static void MaxValue(){
            int a, b;
            Console.WriteLine("Enter a number:");
            while (!int.TryParse(Console.ReadLine(), out a)){
                Console.WriteLine("Invalid number, try again:");
            }
            Console.WriteLine("Enter another number:");
            while (!int.TryParse(Console.ReadLine(), out b)){
                Console.WriteLine("Invalid number, try again:");
            }
            //Console.WriteLine("The maximum value is: " + Math.Max(a, b));
            switch (a > b){
                case true:
                    Console.WriteLine("The maximum value is: " + a);
                    break;
                case false:
                    Console.WriteLine("The maximum value is: " + b);
                    break;
                default:
                    Console.WriteLine("The numbers are equal");
                    break;
            }
        }
    }
}


