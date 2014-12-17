using System.Drawing;
using System.Windows.Forms;

namespace FunctionsExplorer
{
    public partial class FullscreenFunctionForm : Form, IView
    {
        private FunctionView functionView;
        public FullscreenFunctionForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            functionView = new FunctionView
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right
            };
            ClientSize = new Size(functionView.Width, functionView.Height);
            Controls.Add(functionView);
        }

        public void UpdateView(Model model)
        {
            functionView.Draw(model.CurrentFunction);

            Text = model.CurrentFunction.StringRepresentation;
        }
    }
}
