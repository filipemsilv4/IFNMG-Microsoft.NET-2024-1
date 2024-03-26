/*PT: Construa um programa para tratamento de erros para uma calculadora simples de números inteiros (adição, multiplicação e divisão).
O objetivo é ter uma calculadora funcional que retorne uma string com o seguinte padrão: 16 + 51 = 67, quando fornecidos os argumentos 16, 51 e +.

Exceções
Qualquer valor diferente deve gerar ArgumentOutOfRangeException 
Valores vazios ArgumentException 
Null ArgumentNullException 
Divisão por zero

/*EN: Build a program for error handling for a simple integer number calculator (addition, multiplication and division).
The goal is to have a functional calculator that returns a string with the following pattern: 16 + 51 = 67, when provided the arguments 16, 51 and +.
Calculator.Calculate(16, 51, "+");

Exceptions
Any different value should generate ArgumentOutOfRangeException
Empty values ArgumentException
Null ArgumentNullException
Division by zero
*/

using System;

class Calculator {
    private void validate(string num_a, string num_b, string operation){
        if (num_a == null || num_b == null || operation == null){
            throw new ArgumentNullException("Keep your null values inside your public static void. I won't tolerate them here.");
        }

        int a;
        if (!int.TryParse(num_a, out a)){
            throw new ArgumentOutOfRangeException("I can't calculate with " + num_a + ". I only know how to calculate with numbers.");
        }

        int b;
        if (!int.TryParse(num_b, out b)){
            throw new ArgumentOutOfRangeException("I can't calculate with " + num_b + ". I only know how to calculate with numbers.");
        }

        if (operation == "-"){
            throw new ArgumentOutOfRangeException("Subtraction is a government conspiracy. We don't do that here.");
        }

        if (operation != "+" && operation != "*" && operation != "/"){
            throw new ArgumentOutOfRangeException("I have no idea what operation you're trying to do with " + operation + ". I only know how to add, multiply and divide.");
        }

        if (operation == "/" && b == 0){
            throw new DivideByZeroException("Division by zero is illegal and will not be tolerated.");
        }

        // I hope this is enough to validate the input, but it probably isn't.
    }

    public string Calculate(string num_a, string num_b, string operation){
        validate(num_a, num_b, operation);

        int a;
        int b;

        int.TryParse(num_a, out a);
        int.TryParse(num_b, out b);

        int result = 0;
        switch (operation){
            case "+":
                result = a + b;
                break;
            case "*":
                result = a * b;
                break;
            case "/":
                result = a / b;
                break;
        }

        return a + " " + operation + " " + b + " = " + result;
    }

    public string Calculate(int num_a, int num_b, string operation){
        return Calculate(num_a.ToString(), num_b.ToString(), operation);
    }
}

class Program {
    static void Main(string[] args){
        Calculator myCalculator = new Calculator();
        // Read from console
        Console.WriteLine("Enter the first number: ");
        string num_a = Console.ReadLine();
        Console.WriteLine("Enter the second number: ");
        string num_b = Console.ReadLine();

        Console.WriteLine("Enter the operation (+, *, /): ");
        string operation = Console.ReadLine();

        try {
            Console.WriteLine(myCalculator.Calculate(num_a, num_b, operation));
        } catch (Exception e){
            Console.WriteLine(e.Message);
        }
    }
}