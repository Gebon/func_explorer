using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionsExplorer.Functions;
using FunctionsExplorer.Properties;

namespace FunctionsExplorer
{
    public interface IView2
    {
        void UpdateView(Model model);
    }

    public sealed class FunctionsList : Panel
    {
        private ListBox functionsListBox;
        public delegate void SelectedChangedEventHandler(string functionName);

        public event SelectedChangedEventHandler SelectedFunctionChanged;


        public FunctionsList()
        {
            Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            Width = 200;
            Height = 500;
            BorderStyle = BorderStyle.Fixed3D;

            var functionChooseLabel = new Label
            {
                Text = Resources.chooseFunctionLabel,
                Width = Width,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(functionChooseLabel);

            functionsListBox = new ListBox
            {
                Location = new Point(0, functionChooseLabel.Height),
                Size = new Size(Width, Height - functionChooseLabel.Height),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            };
            functionsListBox.SelectedIndexChanged +=
                (sender, args) => { if (SelectedFunctionChanged != null) SelectedFunctionChanged.Invoke((string)functionsListBox.SelectedItem); };

            Controls.Add(functionsListBox);
        }

        public string CurrentSelection()
        {
            return (string)functionsListBox.SelectedItem;
        }

        public void AddFunctions(IEnumerable<BaseFunction> functions)
        {
            foreach (var function in functions.Where(function => !functionsListBox.Items.Contains(function.Name)))
            {
                AddFunction(function);
            }
        }

        public void AddFunction(BaseFunction baseFunction)
        {
            functionsListBox.Items.Add(baseFunction.Name);
        }
    }
}
