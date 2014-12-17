using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FunctionsExplorer.Functions;

namespace FunctionsExplorer
{
    public class Model
    {
        public delegate void UpdatedEventHandler(Model model);

        public event UpdatedEventHandler Updated;
        private BaseFunction currentFunction;

        public BaseFunction CurrentFunction
        {
            get { return currentFunction; }
            set
            {
                currentFunction = value;
                InvokeUpdated();
            }
        }
        private void InvokeUpdated()
        {
            if (Updated != null) Updated.Invoke(this);
        }
        public ICollection<BaseFunction> Functions { get; private set; } 

        public Model()
        {
            Functions = new List<BaseFunction>();
            AddFunctions(new BaseFunction[]{ new LinearFunction(), new QuadraticFunction(), new SinFunction() });
        }
        public BaseFunction GetFunctionByName(string functionName)
        {
            return Functions.FirstOrDefault(func => func.Name == functionName);
        }

        public void AddFunctions(IEnumerable<BaseFunction> functions)
        {
            foreach (var function in functions)
            {
                AddFunction(function);
            }
        }

        public void AddFunction(BaseFunction function)
        {
            function.Changed += () => Updated.Invoke(this);
            Functions.Add(function);
            InvokeUpdated();
        }

        public void AddFunction(string name, string stringRepresentation, Func<double, double> func, Type funcType,
            params int[] coefficients)
        {
            var constructorInfo = funcType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null,
                new[] { typeof(string), typeof(string), typeof(int[]) }, null);

            var function = (BaseFunction)constructorInfo.Invoke(new object[] { name, stringRepresentation, coefficients });
            AddFunction(function);
        }
    }
}
