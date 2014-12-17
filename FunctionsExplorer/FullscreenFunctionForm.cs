using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionsExplorer
{
    public interface IView
    {
        void UpdateView(Model model);
    }
    public partial class FullscreenFunctionForm : Form, IView
    {
        private FunctionView functionView;
        public FullscreenFunctionForm()
        {
            InitializeComponent();
            functionView = new FunctionView();
            Controls.Add(functionView);
            functionView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            ClientSize = new Size(functionView.Width, functionView.Height);
        }

        public void UpdateView(Model model)
        {
            functionView.Draw(model.CurrentFunction);
        }
    }
}
