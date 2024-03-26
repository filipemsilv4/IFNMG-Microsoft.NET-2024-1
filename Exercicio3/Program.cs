// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
1. Escreva um programa em C# que receba dois números inteiros do usuário e exiba o resulta
do das seguintes operações: adição, subtração, multiplicação, divisão inteira e resto d
a divisão entre os números. Pesquisar uma forma de verificar se o tipo está correto.

2. Escreva um programa em C# que utilize uma única expressão lambda para fazer todas as operações 
da questão 1. Em seguida, exiba o resultado na tela.
*/

int num1, num2;

// Lambda function that forces the user to input a valid integer
Func<int> forcarOUsuarioADigitarUmNumeroInteiro = () => {
    string? input = Console.ReadLine();
    int num;
    while (!int.TryParse(input, out num)){
        Console.WriteLine("O valor digitado não é um número válido! Não é tão difícil assim, tente novamente: ");
        input = Console.ReadLine();
    }
    return num;
};

Console.WriteLine("Digite o primeiro número: ");
num1 = forcarOUsuarioADigitarUmNumeroInteiro();
Console.WriteLine("Digite o segundo número: ");
num2 = forcarOUsuarioADigitarUmNumeroInteiro();

Func<int, int, int[]> operacoes = (int a, int b) => {
    return [a + b, a - b, a * b, a / b, a % b];
};

int[] resultadoDasOperacoes = operacoes(num1, num2);

Console.WriteLine("A soma dos números é: " + resultadoDasOperacoes[0]);
Console.WriteLine("A subtração dos números é: " + resultadoDasOperacoes[1]);
Console.WriteLine("A multiplicação dos números é: " + resultadoDasOperacoes[2]);
Console.WriteLine("A divisão inteira dos números é: " + resultadoDasOperacoes[3]);
Console.WriteLine("O resto da divisão dos números é: " + resultadoDasOperacoes[4]);
