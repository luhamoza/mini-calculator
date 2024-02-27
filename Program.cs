using System.Xml;

namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        Greeting();

        (int num1, int num2) = GetNumbers();
        DisplayMenu();

        int choice = AskUserChoice();
        UserChoice(choice, num1, num2);

        AmountOfOperationsUsed(choice);
        Console.WriteLine();

        string? seeList = AskUserToSeeTheLatestCalculation(num1, num2, choice);
        Console.WriteLine();

        // allow user to use the result of the previous calculation for another calculation
        Console.Write("Would you like to use the result of the previous calculation for another calculation? (yes/no): ");
        string? useResult = Console.ReadLine();
        if (useResult?.ToLower() == "yes")
        {

            Main(args);
        }

        string? anotherCalculation = AskUserForAnotherCalculation();
        if (anotherCalculation?.ToLower() == "yes")
        {
            Console.WriteLine();
            Main(args);
        }
        Console.WriteLine();

        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
    }
    private static string AskUserToSeeTheLatestCalculation(int num1, int num2, int choice)
    {
        Console.Write("Would you like to see the latest calculations? (yes/no): ");
        string? seeList = Console.ReadLine();
        if (seeList?.ToLower() != "yes" && seeList?.ToLower() != "no")
        {
            Console.WriteLine("Invalid input. Please try again.");
            return AskUserToSeeTheLatestCalculation(num1, num2, choice);
        }
        if (seeList?.ToLower() == "yes")
        {
            LatestCalculations(num1, num2, choice);
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }
        return seeList ?? ""; // Return a non-null value
    }
    private static int OperationUsed = 0;
    private static void AmountOfOperationsUsed(int choice)
    {
        if (choice == 1 || choice == 2 || choice == 3 || choice == 4)
        {
            OperationUsed++;
        }
        Console.WriteLine($"You have use calculator {OperationUsed} times.");
    }
    private static void LatestCalculations(int num1, int num2, int choice)
    {
        List<string> operations = new List<string>();
        Console.WriteLine();
        if (choice == 1)
        {
            operations.Add($"The addition of {num1} and {num2} is {num1 + num2}");
        }
        if (choice == 2)
        {
            operations.Add($"The substraction of {num1} and {num2} is {num1 - num2}");
        }
        if (choice == 3)
        {
            operations.Add($"The multiplication of {num1} and {num2} is {num1 * num2}");
        }
        if (choice == 4)
        {
            operations.Add($"The division of {num1} and {num2} is {num1 / num2}");
        }

        // display the list of calculations
        Console.WriteLine("Latest calculations: ");
        foreach (string operation in operations)
        {
            Console.WriteLine(operation);
        }
        Console.WriteLine();

        // give user ability to delete the list
        Console.Write("Would you like to delete the latest calculations? (yes/no): ");
        string? deleteList = Console.ReadLine();
        if (deleteList?.ToLower() == "yes")
        {
            operations.Clear();
            Console.WriteLine("List has been deleted.");
        }
        else
        {
            Console.WriteLine("List has not been deleted.");
        }
    }

    private static int AskUserChoice()
    {
        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        return choice;
    }
    private static string AskUserForAnotherCalculation()
    {
        Console.Write("Would you like to do another calculation? (yes/no): ");
        string? output = Console.ReadLine();
        if (output?.ToLower() != "yes" && output?.ToLower() != "no")
        {
            Console.WriteLine("Invalid input. Please try again.");
            return AskUserForAnotherCalculation();
        }
        return output;
    }
    private static void UserChoice(int choice, int num1, int num2)
    {
        switch (choice)
        {
            case 1:
                Addition(num1, num2);
                break;
            case 2:
                Subtraction(num1, num2);
                break;
            case 3:
                Multiplication(num1, num2);
                break;
            case 4:
                Division(num1, num2);
                break;
            case 5:
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    private static void Division(int num1, int num2)
    {
        while (num2 == 0)
        {
            Console.Write("The second number cannot be zero. Please enter a valid number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
        }
        int output = num1 / num2;
        string operation = "division";
        PrintResult(num1, num2, output, operation);
    }
    private static void Multiplication(int num1, int num2)
    {
        int output = num1 * num2;
        string operation = "multiplication";
        PrintResult(num1, num2, output, operation);
    }
    private static void Subtraction(int num1, int num2)
    {
        int output = num1 - num2;
        string operation = "subtraction";
        PrintResult(num1, num2, output, operation);
    }
    private static void Addition(int num1, int num2)
    {
        int output = num1 + num2;
        string operation = "addition";
        PrintResult(num1, num2, output, operation);
    }
    private static string PrintResult(int num1, int num2, int result, string operation)
    {
        Console.WriteLine($"The {operation} of {num1} and {num2} is {result}");
        return $"{num1} {operation} {num2} = {result}";
    }
    private static (int, int) GetNumbers()
    {
        int num1, num2;
        do
        {
            Console.Write("Enter the first number: ");
            string? input1 = Console.ReadLine();
            if (int.TryParse(input1, out num1))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

        } while (true);

        do
        {
            Console.Write("Enter the second number: ");
            string? input2 = Console.ReadLine();
            if (int.TryParse(input2, out num2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        } while (true);

        return (num1, num2);
    }

    private static void Greeting()
    {
        Console.WriteLine("Welcome to the Calculator");
        Console.WriteLine("This program will ask you to enter two numbers and then choose an operation to perform on them.");
        Console.WriteLine();
    }
    private static void DisplayMenu()
    {
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Exit");
    }
}
