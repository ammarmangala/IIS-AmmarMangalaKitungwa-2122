// See https://aka.ms/new-console-template for more informations
//variables
string userName;
int age;
string playerResponse;
string mathProblem;
string userValue;
int answer;
string keepPlaying;
bool ageQuestion;
bool answerCheck;
int num1;
int num2;
int mathAnswer;


Console.WriteLine("What is your name?");
userName = Console.ReadLine();
Console.WriteLine(userName + "! That is a wonderful name!");



ageQuestion = true;
while (ageQuestion)
{
    Console.WriteLine("How old are you, " + userName + "?");

    if (int.TryParse(Console.ReadLine(), out age))
    {
        Console.WriteLine(age + " years old! You must be very smart.");
        break;
    }
    else
    {
        Console.WriteLine("Sorry. I don't understand that answer.");
    }
}
#region 


bool userAnswer = true;
while (userAnswer)
{
    Console.WriteLine("Would you like to do some math problems? Press Y for Yes and N for No.");
    playerResponse = Console.ReadLine();
    if (playerResponse.ToUpper() == "YES" || playerResponse.ToUpper() == "Y")
    {
        Console.WriteLine("Great! Let's get started.");
        Console.WriteLine("Complete the following equation");
        break;
    }
    else if (playerResponse.ToUpper() == "NO" || playerResponse.ToUpper() == "N")
    {
        Console.WriteLine("Are you sure. Math is fun!");
    }
    else
    {
        Console.WriteLine("Sorry. I don't understand that answer.");
    }
}


int correctCount = 0;
bool userPlays = true;
while (userPlays)
{

    bool questionCycle = true;
    while (questionCycle)
    {
        Random rnd = new Random();
        num1 = rnd.Next(10);
        num2 = rnd.Next(10);
        mathAnswer = num1 + num2;

        mathProblem = num1.ToString() + " + " + num2.ToString() + " = ";
        Console.WriteLine(mathProblem);

        #endregion


        userValue = Console.ReadLine();
        answer = Convert.ToInt32(userValue);


        if (mathAnswer == answer)
        {
            Console.WriteLine("Correct!");
            correctCount = correctCount + 1;

            if (correctCount % 5 == 0)
            {
                break;
            }
        }
        else
        {
            Console.WriteLine("Incorrect. The Correct answer is " + mathAnswer);
        }
    }



    bool continuePlaying = true;
    while (continuePlaying)
    {
        Console.WriteLine("You've answered " + correctCount + " questions correctly! Great job. " +
                          "Would you like to keep playing? Press Y for Yes and N for No.");
        keepPlaying = Console.ReadLine();
        {
            if (keepPlaying.ToUpper() == "YES" || keepPlaying.ToUpper() == "Y")
            {
                Console.WriteLine();
                break;
            }
            else if (keepPlaying.ToUpper() == "NO" || keepPlaying.ToUpper() == "N")
            {
                Console.WriteLine("Goodbye.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Sorry. I don't understand that answer.");
            }
        }
    }
}
Console.ReadLine();


