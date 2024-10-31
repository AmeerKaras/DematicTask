using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Operations
{
    public class DivisionOperation : Operation
    {
        public override double Calculate()
        {
            if (!Values.Any()) return 0; 
            if (Values.Skip(1).Contains(0)) throw new DivideByZeroException("Division by zero is not allowed.");

            return Values.Skip(1).Aggregate(Values[0], (acc, val) => acc / val);
        }
    }
}
