using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Operations
{
    using global::CalculatorComplexOperations.Operations;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;

    namespace CalculatorApp.Operations
    {
        public static class OperationHandler
        {
            public static IMathOperation CreateOperation(JObject json)
            {
                var operatorType = json["Operator"]?.ToString();
                var valuesArray = json["Values"]?.ToObject<List<double>>() ?? new List<double>();
                var subOperationsArray = json["SubOperations"] as JArray;

                IMathOperation operation;

                switch (operatorType)
                {
                    case "Addition":
                        operation = new AdditionOperation { Values = valuesArray };
                        break;
                    case "Multiplication":
                        operation = new MultiplicationOperation { Values = valuesArray };
                        break;
                    case "Subtraction":
                        operation = new SubtractionOperation { Values = valuesArray };
                        break;
                    case "Division":
                        operation = new DivisionOperation { Values = valuesArray };
                        break;
                    default:
                        throw new InvalidOperationException("Invalid or unsupported operation type.");
                }

                if (subOperationsArray != null)
                {
                    foreach (var subOperationJson in subOperationsArray)
                    {
                        var subOperation = CreateOperation((JObject)subOperationJson);
                        ((Operation)operation).SubOperations.Add(subOperation);
                    }
                }

                return operation;
            }
        }
    }
}