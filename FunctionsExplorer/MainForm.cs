using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FunctionsExplorer.Properties;

namespace FunctionsExplorer
{
    public sealed class MainForm : Form, IFullView
    {
    
        private FunctionsList functionsList;
        private FunctionView functionView;
        private ParametersView parametersView;
        private Actions actions;
        public MainForm()
        {
            BuildLayout();

            Controls.Add(functionsList);
            Controls.Add(functionView);
            Controls.Add(parametersView);
            Controls.Add(actions);

            InitializeComponent();


            functionsList.SelectedFunctionChanged += name => SelectedFunctionChanged.Invoke(name);
            var resetButton = actions.Controls["Reset"];
            resetButton.Click += (sender, args) => ResetButtonClicked.Invoke(functionsList.CurrentSelection());

            var saveButton = actions.Controls["Save"];
            saveButton.Click +=
                (sender, args) =>
                {
                    var nameGetter = new NameGetterForm();
                    nameGetter.Controls["okButton"].Click += (o, eventArgs) =>
                    {
                        var newName = nameGetter.Controls.OfType<TextBox>().First().Text;
                        SaveButtonClicked.Invoke(functionsList.CurrentSelection(), newName,
                            parametersView.GetCoefficients());
                        nameGetter.Close();
                    };
                    nameGetter.ShowDialog(this);
                };

            var openButton = actions.Controls["Open"];
            openButton.Click += (sender, args) => { if (OpenCurrent != null) OpenCurrent.Invoke(sender, args); };

            parametersView.ParameterUpDownsChanged +=
                downs => { if (ParameterUpDownsChanged != null) ParameterUpDownsChanged.Invoke(downs); };
        }

        private void BuildLayout()
        {
            functionsList = new FunctionsList {Location = new Point(0, 0)};

            functionView = new FunctionView
            {
                Location = new Point(200, 0),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left
            };

            parametersView = new ParametersView
            {
                Location = new Point(functionsList.Width, functionView.Height),
                Width = 200,
                Height = functionsList.Height - functionView.Height,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };

            actions = new Actions
            {
                Location = new Point(functionsList.Width + parametersView.Width, functionView.Height),
                Width = functionView.Width - parametersView.Width,
                Height = parametersView.Height,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left
            };
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(functionsList.Width + functionView.Width, functionsList.Height);
            MinimumSize = new Size(Width, Height);
            Name = "MainForm";
            Text = Resources.mainFromTitle;
            ResumeLayout(false);
        }

        public event Actions.ResetButtonClickedEventHandler ResetButtonClicked;
        public event Actions.SaveButtonClickedEventHandler SaveButtonClicked;
        public event FunctionsList.SelectedChangedEventHandler SelectedFunctionChanged;
        public event ParametersView.ParameterUpDownsChangedEventHandler ParameterUpDownsChanged;
        public event EventHandler OpenCurrent;


        public void UpdateView(Model model)
        {
            functionsList.AddFunctions(model.Functions);
            if (model.CurrentFunction == null) return;
           
            functionView.Draw(model.CurrentFunction);
            parametersView.CreateParams(model.CurrentFunction);


            parametersView.DrawFunctionStringRepresentation(model.CurrentFunction);

        }
    }
}
