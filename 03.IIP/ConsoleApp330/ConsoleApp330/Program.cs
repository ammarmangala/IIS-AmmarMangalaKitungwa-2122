// See https://aka.ms/new-console-template for more information
int num1;
Console.Write("Enter the 1st Number : ");
num1 = Convert.ToInt32(Console.ReadLine());

int num2;
Console.Write("Enter the 2nd Number : ");
num2 = Convert.ToInt32(Console.ReadLine());

int rem = 0;


while (num2 > 0)
{
    rem = num1 % num2;
    num1 = num2;
    num2 = rem;
}
Console.WriteLine(" het grootste gemene deler is " + num1);