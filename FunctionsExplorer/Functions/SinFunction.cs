using System;

namespace FunctionsExplorer.Functions
{
    public class SinFunction : BaseFunction
    {
        public SinFunction()
            : this("Sin", "y = a*sin(b*x)", new[] { 1, 1 })
        {
        }

        public SinFunction(string functionName, string stringRepresentation,
            params int[] coefficients)
        {
            Name = functionName;
            StringRepresentation = stringRepresentation;

            Func = d => Coefficients[1] * Math.Sin(Coefficients[0] * d);
            Coefficients = coefficients;
        }
    }
}