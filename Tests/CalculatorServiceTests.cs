using CalculatorComplexOperations.Operations;
using CalculatorComplexOperations.Services;
using CalculatorComplexOperations.Operations.CalculatorApp.Operations;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace CalculatorComplexOperations.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void TestSimpleAddition()
        {
            var operation = new AdditionOperation { Values = new List<double> { 2, 3 } };
            var calculatorService = new CalculatorService();

            double result = calculatorService.Calculate(operation);

            Assert.Equal(5, result);
        }

        [Fact]
        public void TestSimpleSubtraction()
        {
            var operation = new SubtractionOperation { Values = new List<double> { 4, 3 } };
            var calculatorService = new CalculatorService();

            double result = calculatorService.Calculate(operation);

            Assert.Equal(1, result);
        }

        [Fact]
        public void TestSimpleMultiplication()
        {
            var operation = new MultiplicationOperation { Values = new List<double> { 4, 7 } };
            var calculatorService = new CalculatorService();

            double result = calculatorService.Calculate(operation);

            Assert.Equal(28, result);
        }

        [Fact]
        public void TestSimpleDivision()
        {
            var operation = new DivisionOperation { Values = new List<double> { 16, 4 } };
            var calculatorService = new CalculatorService();

            double result = calculatorService.Calculate(operation);

            Assert.Equal(4, result);
        }

        [Fact]
        public void TestComplexOperation()
        {
            var additionOperation = new AdditionOperation { Values = new List<double> { 2, 3 } };
            var multiplicationOperation = new MultiplicationOperation { Values = new List<double> { 4, 5 } };

            additionOperation.SubOperations.Add(multiplicationOperation);

            var calculatorService = new CalculatorService();

            double result = calculatorService.Calculate(additionOperation);

            Assert.Equal(25, result);
        }

        [Fact]
        public void TestInvalidOperationThrowsException()
        {
            var json = new JObject
            {
                ["Operator"] = "Unsupported",
                ["Values"] = new JArray { 2, 3 }
            };

            Assert.Throws<InvalidOperationException>(() => OperationHandler.CreateOperation(json));
        }
    }
}