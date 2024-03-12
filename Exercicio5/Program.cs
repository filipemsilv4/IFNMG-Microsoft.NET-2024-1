// 1. Create a program that calculates the value of an installment of a certain financing. The user must provide the monthly interest rate, the number of installments, and the value of the asset. The program should provide the value of the installment and allow the operation to be repeated.

using System;

//monthly interest rate, the number of installments, and the value of the asset.
double monthlyInterestRate, assetValue;
int numberOfInstallments;

// Lambda function that calculates the value of an installment
Func<double, int, double, double> calculateInstallment = (double monthlyInterestRate, int numberOfInstallments, double assetValue) => {
    // EN: formula: financingCoefficient = interestRate / (1 - Math.Pow(1 + interestRate), -numberOfInstallments)
    double financingCoefficient = monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfInstallments));
    return assetValue * financingCoefficient;
};

//The program should provide the value of the installment and allow the operation to be repeated.
char c;
do {
    Console.WriteLine("Enter the monthly interest rate: ");
    monthlyInterestRate = SafeInput<double>() / 100;
    Console.WriteLine("Enter the number of installments: ");
    numberOfInstallments = SafeInput<int>();
    Console.WriteLine("Enter the value of the asset: ");
    assetValue = SafeInput<double>();
    Console.WriteLine("The value of the installment is: " + calculateInstallment(monthlyInterestRate, numberOfInstallments, assetValue).ToString("F2"));
    Console.WriteLine("Do you want to calculate another installment? (y/n)");
    c = SafeInput<char>();
} while (c == 'y');

static T SafeInput<T>() where T : struct{
        T value;
        string? input;

        input = Console.ReadLine();
        while (!TryParse(input, out value)){
            Console.WriteLine("Invalid input! Please try again: ");
            input = Console.ReadLine();
        }

        return value;
}

static bool TryParse<T>(string? input, out T value) where T : struct{
    Type targetType = typeof(T);

    try{
        // Utilize conversion methods for the types that don't have a TryParse method
        if (targetType == typeof(double)){
            value = (T)(object)double.Parse(input);
            return true;
        }
        else if (targetType == typeof(int)){
            value = (T)(object)int.Parse(input);
            return true;
        }
        else if (targetType == typeof(char)){
            char result;
            if (char.TryParse(input, out result)){
                value = (T)(object)result;
                return true;
            }
        }

        value = default(T);
        return false;
    }
    catch (Exception){
        value = default(T);
        return false;
    }
}