using Microsoft.ServiceModel.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ServiceModel.Samples
{
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }
    }
}
