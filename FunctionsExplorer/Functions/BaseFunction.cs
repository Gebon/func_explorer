using System;
using System.Collections.Generic;

namespace FunctionsExplorer.Functions
{
    public abstract class BaseFunction
    {
        public delegate void ChangedEventHandler();

        public event ChangedEventHandler Changed;
        public IEnumerable<PointD> ResultPoints { get; protected set; }
        public string Name { get; protected set; }
        private int[] coefficients;
        public int[] Coefficients
        {
            get { return coefficients; }

            protected set
            {
                coefficients = value;
                CalculateResult();
                initialCoefficitents = new int[value.Length];
                value.CopyTo(initialCoefficitents, 0);
            }
        }
        private int[] initialCoefficitents;
        public Func<double, double> Func { get; protected set; }

        public void CalculateResult()
        {
            var result = new List<PointD>(60 * 5);

            for (double i = -30; i <= 30; i += 0.2)
            {
                result.Add(new PointD(i, Func(i)));
            }
            ResultPoints = result;

            if (Changed != null) Changed.Invoke();
        }
        public string StringRepresentation { get; protected set; }

        public void ResetToDefault()
        {
            initialCoefficitents.CopyTo(Coefficients, 0);
            CalculateResult();
        }
    }
}