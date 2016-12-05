using System;
using System.Globalization;
using System.ServiceModel;

namespace WcfCalculatorService
{
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            var result = a + b;
            CheckCalculationResult(result);
            return result;
        }

        public double Substract(double a, double b)
        {
            var result = a - b;
            CheckCalculationResult(result);
            return result;
        }

        public double Multiply(double a, double b)
        {
            var result = a * b;
            CheckCalculationResult(result);
            return result;
        }

        public double Divide(double a, double b)
        {
            if (b.Equals(0))
            {
                throw new FaultException<DivideByZeroException>(
                    new DivideByZeroException(),
                    new FaultReason(new FaultReasonText("Divide by 0",
                    CultureInfo.CurrentCulture)));
            }

            var result = a / b;
            CheckCalculationResult(result);
            return result;
        }

        public double Sqrt(double a)
        {
            var result = Math.Sqrt(a);
            CheckCalculationResult(result);
            return result;
        }

        private void CheckCalculationResult(double result)
        {
            ThrowExceptionIfInfinity(result);
            ThrowExceptionIfNaN(result);
        }

        private void ThrowExceptionIfInfinity(double result)
        {
            if (double.IsInfinity(result))
            {
                throw new FaultException<CalculationFault>(
                    new CalculationFault("Infinity"),
                    new FaultReason(new FaultReasonText("The value is out of range",
                    CultureInfo.CurrentCulture)));
            }
        }

        private void ThrowExceptionIfNaN(double result)
        {
            if (double.IsNaN(result))
            {
                throw new FaultException<CalculationFault>(
                    new CalculationFault("Not a number"),
                    new FaultReason(new FaultReasonText("The value is not a number", 
                    CultureInfo.CurrentCulture)));
            }
        }
    }
}
