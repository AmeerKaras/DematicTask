using CalculatorComplexOperations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexOperations.Services
{
    public interface ICalculatorService
    {
        double Calculate(IMathOperation operation);
    }
}

