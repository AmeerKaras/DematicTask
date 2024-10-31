using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorComplexOperations.Operations;
using CalculatorComplexOperations.Services;

namespace CalculatorComplexOperations.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double Calculate(IMathOperation operation)
        {
            double result = operation.Calculate();

            if (operation is Operation operationBase && operationBase.SubOperations.Count > 0)
            {
                foreach (var subOperation in operationBase.SubOperations)
                {
                    result += Calculate(subOperation);
                }
            }

            return result;
        }
    }
}