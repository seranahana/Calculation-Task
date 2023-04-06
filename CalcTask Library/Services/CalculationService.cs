using CalcTask.WebAPI.Library.Evaluation;
using System.Data;

namespace CalcTask.WebAPI.Library.Services
{
    public class CalculationService : ICalculationService
    {

        public double Add(double value, double addend)
        {
            double s = value + addend;
            if (double.IsInfinity(s) || double.IsNaN(s))
                throw new OverflowException();
            return s;
        }

        public double Divide(double value, double divisor)
        {
            double s = value / divisor;
            if (double.IsInfinity(s) || double.IsNaN(s))
                throw new OverflowException();
            return s;
        }

        public double EvaluateExpression(string expression)
        {
            return ExpressionEvaluator.Evaluate(expression);
        }

        public double Multiply(double value, double multiplier)
        {
            double s = value * multiplier;
            if (double.IsInfinity(s) || double.IsNaN(s))
                throw new OverflowException();
            return s;
        }

        public double NthRoot(double value, double n)
        {
            double power = 1.0 / n;
            return this.Pow(value, power);
        }

        public double Pow(double value, double power)
        {
            double s = Math.Pow(value, power);
            if (double.IsInfinity(s) || double.IsNaN(s))
                throw new OverflowException();
            return s;
        }

        public double Substract(double value, double substrahend)
        {
            double s = value - substrahend;
            if (double.IsInfinity(s) || double.IsNaN(s))
                throw new OverflowException();
            return s;
        }
    }
}
