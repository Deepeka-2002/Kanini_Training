using System;
int num1, num2;
readData();

void readData()
{
    Console.WriteLine("Num1: ");
    num1 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Num2: ");
    num2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Sum: ");
    Console.WriteLine(num1 + num2);
    Console.ReadLine();
}