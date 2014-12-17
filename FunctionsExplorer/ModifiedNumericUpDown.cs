using System.Windows.Forms;

namespace FunctionsExplorer
{
    public class ModifiedNumericUpDown : NumericUpDown
    {
        public delegate void ValueChangedHandler(decimal value);

        public new event ValueChangedHandler ValueChanged;

        public int CoefficientIndex { get; private set; }

        public ModifiedNumericUpDown(int coefficientIndex) : base()
        {
            CoefficientIndex = coefficientIndex;
            base.ValueChanged += (sender, args) => { if (ValueChanged != null) ValueChanged.Invoke(Value); };
        }
    }
}