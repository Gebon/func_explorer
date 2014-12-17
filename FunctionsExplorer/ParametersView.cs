using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FunctionsExplorer.Functions;

namespace FunctionsExplorer
{
    public class ParametersView : Panel
    {
        public delegate void ParameterUpDownsChangedEventHandler(IEnumerable<ModifiedNumericUpDown> upDowns);

        public event ParameterUpDownsChangedEventHandler ParameterUpDownsChanged;

        private readonly string[] paramNames = { "a = ", "b = ", "c = ", "d = " };

        public ParametersView()
        {
            BorderStyle = BorderStyle.Fixed3D;
        }

        public int[] GetCoefficients()
        {
            return Controls
                .OfType<ModifiedNumericUpDown>()
                .OrderBy(x => x.Name)
                .Select(x => (int) x.Value)
                .Reverse()
                .ToArray();
        }

        public void CreateParams(BaseFunction function)
        {
            var upDowns = new List<ModifiedNumericUpDown>();
            var initialCoefficients = function.Coefficients.Reverse().ToArray();
            Controls.Clear();
            for (int i = 0; i < initialCoefficients.Length; i++)
            {
                var height = 30 + 25 * (i + 1);
                var paramName = new Label
                {
                    Text = paramNames[i],
                    Location = new Point(20, height),
                    AutoSize = true
                };
                var param = new ModifiedNumericUpDown(initialCoefficients.Length - 1 - i)
                {
                    Name = i.ToString(CultureInfo.InvariantCulture),
                    Size = new Size(60, 20),
                    Location = new Point(50, height),
                    Minimum = -9999,
                    Maximum = 9999,
                    Value = initialCoefficients[i]
                };
                Controls.Add(paramName);
                Controls.Add(param);
                upDowns.Add(param);
            }
            if (ParameterUpDownsChanged != null) ParameterUpDownsChanged.Invoke(upDowns);
        }

        public void DrawFunctionStringRepresentation(BaseFunction function)
        {
            var label = new Label { Text = function.StringRepresentation, AutoSize = true, Location = new Point(50, 8) };
            Controls.Add(label);
        }
    }
}
