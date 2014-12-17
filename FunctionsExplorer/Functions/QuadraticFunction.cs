namespace FunctionsExplorer.Functions
{
    public class QuadraticFunction : BaseFunction
    {
        public QuadraticFunction() : this("Quadratic", "y = a*x^2 + b*x + c", new[] { 1, -3, 1 })
        {
        }

        public QuadraticFunction(string functionName, string stringRepresentation,
            params int[] coefficients)
        {
            Name = functionName;
            StringRepresentation = stringRepresentation;

            Func = d => Coefficients[2] * d * d + Coefficients[1] * d + Coefficients[0];
            Coefficients = coefficients;
        }
    }
}