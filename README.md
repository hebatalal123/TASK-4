1. Write a C# program that reads a list of integers from the user and throws an exception if any numbers are duplicates.using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter numbers separated by spaces: ");
            string input = Console.ReadLine();

            string[] values = input.Split(' ');
            List<int> numbers = new List<int>();

            foreach (string value in values)
            {
                int number = int.Parse(value);

                if (numbers.Contains(number))
                {
                    throw new Exception("Duplicate number found!");
                }

                numbers.Add(number);
            }

            Console.WriteLine("No duplicates found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


2. Write a C# program to create a method that takes a string as input and throws an exception if the string does not contain vowels.

using System;

class Program
{
    static void CheckVowels(string text)
    {
        string vowels = "aeiouAEIOU";
        bool hasVowel = false;

        foreach (char c in text)
        {
            if (vowels.Contains(c))
            {
                hasVowel = true;
                break;
            }
        }

        if (!hasVowel)
        {
            throw new Exception("The string does not contain any vowels.");
        }

        Console.WriteLine("The string contains vowels.");
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            CheckVowels(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
