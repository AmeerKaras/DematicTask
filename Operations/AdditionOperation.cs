using CalculatorComplexOperations.Operations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Operations
{
    public class AdditionOperation : Operation
    {
        public override double Calculate()
        {
            return Values.Sum();
        }
    }
}