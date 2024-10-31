using System;
using Newtonsoft.Json.Linq;
using CalculatorComplexOperations.Services;
using CalculatorComplexOperations.Operations;
using CalculatorComplexOperations.Operations.CalculatorApp.Operations;

namespace CalculatorComplexOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CalculatorService calculatorService = new CalculatorService();

            Console.WriteLine("Enter a JSON-formatted calculation:");
            Console.WriteLine("Example: {\"Operator\": \"Addition\", \"Values\": [2, 3], \"SubOperations\": [{\"Operator\": \"Multiplication\", \"Values\": [4, 5]}]}");
            Console.WriteLine("The SubOperation is addition between operations. For example, the above calculation equates to: 2 + 3 + (4 x 5)");


            string jsonInput = Console.ReadLine();

            try
            {
                JObject jsonObject = JObject.Parse(jsonInput);
                IMathOperation complexOperation = OperationHandler.CreateOperation(jsonObject);
                double result = calculatorService.Calculate(complexOperation);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Invalid JSON format or operation. Please try again.");
                Console.WriteLine("Exception Message: " + ex.Message);
            }
        }
    }
}