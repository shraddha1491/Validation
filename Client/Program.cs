using Common.Logging;
using System;
using Validation;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            IValidator validator = new StringValidator(logger);
               
            Console.WriteLine("Provide input string");
            string input = Console.ReadLine();

            var result = validator.Validate(input);

            Console.WriteLine(result.ToString());
            Console.WriteLine("Enter to Exit");
            Console.ReadLine();

        }

    }
}
