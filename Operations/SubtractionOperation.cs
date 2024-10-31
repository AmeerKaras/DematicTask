using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Operations
{
    public class SubtractionOperation : Operation
    {
        public override double Calculate()
        {
            if (!Values.Any()) return 0;

            return Values.Skip(1).Aggregate(Values[0], (acc, val) => acc - val);
        }
    }
}
