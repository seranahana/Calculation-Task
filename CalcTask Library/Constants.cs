namespace CalcTask.WebAPI.Library
{
    internal class Constants
    {
        internal static readonly Dictionary<Params, string> ParamNames = new()
        {
            { Params.Expression, "expression" }
        };
    }

    public enum Params
    {
        Expression
    }
}
