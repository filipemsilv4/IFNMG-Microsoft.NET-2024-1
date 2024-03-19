/* PT: Crie um programa que receba um conjunto de dados de entrada (int), que deve ser fornecido pelo usuário sequencialmente, sem tamanho pré-definido. */

/* EN: Create a program that receives a set of input data (int), which must be provided by the user sequentially, without a predefined size.*/

using System;

List<int> list = new List<int>();
Calculator calculator = new Calculator();

int option = 1;
while (option != 3){
    if (option == 1){
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());
        calculator.AddNumber(number);
    }
    else if (option == 2){
        Console.WriteLine(calculator.ToString());
    }
    else if (option == 3){
        break;
    }
    else{
        Console.WriteLine("Invalid option");
    }
    Console.WriteLine(" | 1 - Add number\n" +
                      " | 2 - Show average and standard deviation\n" +
                      " | 3 - Exit");
    Console.Write(" > Choose an option: ");
    option = int.Parse(Console.ReadLine());
}

/* PT: Implemente uma classe, que armazene e calcule a média e o desvio padrão dos dados fornecidos. Essa classe deve ter pelo menos um construtor, as propriedades (get e set), um método para receber um número da sequência, um para calcular a média e outro para o desvio padrão, e uma sobrecarga para ToString(). O usuário deve escolher se quer adicionar mais um número, ou verificar a média e o desvio ou finalizar.*/

/* EN: Implement a class that stores and calculates the average and standard deviation of the provided data. This class must have at least one constructor, properties (get and set), a method to receive a number from the sequence, one to calculate the average and another for the standard deviation, and an overload for ToString(). The user must choose whether to add another number, or check the average and standard deviation, or finish.*/

class Calculator {
    private double average, standardDeviation;
    private List<int> Numbers { get; set; } = new List<int>();

    public Calculator(){
        average = 0;
        standardDeviation = 0;
    }

    public void AddNumber(int number){ 
        Numbers.Add(number);
    }

    public double CalculateAverage(){
        average = Numbers.Average();
        return average;
    }

    public double CalculateStandardDeviation(){
        CalculateAverage();
        standardDeviation = Math.Sqrt(Numbers.Average(v => Math.Pow(v - average, 2)));
        return standardDeviation;
    }

    public override string ToString(){
        return $"Average: {average}\nStandard Deviation: {standardDeviation}";
    }

    public void Clear(){
        Numbers.Clear();
        average = 0;
        standardDeviation = 0;
    }

}