using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CalcTask.WebAPI.Library.Services
{
    public class CalculationService : ICalculationService
    {
        public double Add(double value, double addend)
        {
            double s = value + addend;
            return s;
        }

        public double Divide(double value, double divisor)
        {
            double s = value / divisor;
            return s;
        }

        public double Multiply(double value, double multiplier)
        {
            double s = value * multiplier;
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
            return s;
        }

        public double Substract(double value, double substrahend)
        {
            double s = value - substrahend;
            return s;
        }
    }
}
