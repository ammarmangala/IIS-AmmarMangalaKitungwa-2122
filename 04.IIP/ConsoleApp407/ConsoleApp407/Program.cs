// See https://aka.ms/new-console-template for more information
while (true)
{
    Console.Write("Hoeveel Fibonacci getallen wenst u te zien? : ");
    int count = int.Parse(Console.ReadLine()); int[] numbers = new int[count]; if (count == 1)
    {
        numbers[0] = 1;
        Console.Write("count: ");
        Console.Write(numbers[0]);
        Console.WriteLine();
    }
    else if (count == 2)
    {
        numbers[0] = 1;
        numbers[1] = 1;
        Console.Write("count: ");
        Console.Write(numbers[0] + " " + numbers[1]);
        Console.WriteLine();
    } 
    
    else (count >= 3)
    {
        numbers[0] = 1;
        numbers[1] = 1;
        Console.Write("count: ");
        Console.Write(numbers[0] + " " + numbers[1] + " ");
        for (int index = 2; index < count; index++)
        {
            numbers[index] = numbers[(index - 2)] + numbers[(index - 1)]; Console.Write(numbers[index] + " ");
        }
        Console.WriteLine();
    }
}

