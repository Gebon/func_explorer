using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FunctionsExplorer.Properties;

namespace FunctionsExplorer
{
    public class Actions : FlowLayoutPanel
    {
        public delegate void SaveButtonClickedEventHandler(string functionName, string newName, params int[] coefficients);

        public delegate void ResetButtonClickedEventHandler(string functionName);

        public Actions()
        {
            BorderStyle = BorderStyle.Fixed3D;

            var resetButton = new Button
            {
                Name = "Reset",
                Text = Resources.resetToDefaultLabel,
                AutoSize = true,
                //Location = new Point(70, 30)
            };
            Controls.Add(resetButton);

            var saveButton = new Button
            {
                Name = "Save",
                Text = Resources.saveFunctionLabel,
                AutoSize = true,
                //Location = new Point(200, 100)
            };
            Controls.Add(saveButton);

            var openButton = new Button
            {
                Name = "Open",
                Text = Resources.openFullscreenLabel,
                AutoSize = true
            };
            Controls.Add(openButton);
        }
    }
}
