namespace FunctionsExplorer.Functions
{
    public sealed class LinearFunction : BaseFunction
    {
        public LinearFunction() : this("Linear", "y = a*x + b", new[] {0, 1})
        {
        }
        public LinearFunction(string functionName, string stringRepresentation,
            params int[] coefficients)
        {
            Name = functionName;
            StringRepresentation = stringRepresentation;

            Func = d => Coefficients[1] * d + Coefficients[0];
            Coefficients = coefficients;
        }
    }
}