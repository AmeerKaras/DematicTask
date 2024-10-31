using CalculatorComplexOperations.Operations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Operations
{
    public class MultiplicationOperation : Operation
    {
        public override double Calculate()
        {
            return Values.Aggregate(1.0, (acc, val) => acc * val);
        }
    }
}