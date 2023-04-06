namespace CalcTask.WebAPI.Library.Services
{
    public interface ICalculationService
    {
        double Add(double value, double addend);
        double Divide(double value, double divisor);
        double Multiply(double value, double multiplier);
        double Substract(double value, double substrahend);
        double NthRoot(double value, double n);
        double Pow(double value, double power);
    }
}
