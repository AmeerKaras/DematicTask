using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Operations
{
    public abstract class Operation : IMathOperation
    {
        public List<double> Values { get; set; } = new List<double>();
        public List<IMathOperation> SubOperations { get; set; } = new List<IMathOperation>();

        public abstract double Calculate();
    }
}