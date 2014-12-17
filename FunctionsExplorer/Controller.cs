namespace FunctionsExplorer
{
    public class Controller
    {
        public IFullView View { get; private set; }
        public Model Model { get; private set; }

        public Controller(IFullView view)
        {
            Model = new Model();

            View = view;
            Model.Updated += View.UpdateView;
            View.OpenCurrent +=
                (sender, args) =>
                {
                    var form = new FullscreenFunctionForm();
                    form.Show();
                    var controller = new FunctionFullscreenController(form, Model);
                };
            View.UpdateView(Model);

            View.ResetButtonClicked += name => Model
                .GetFunctionByName(name)
                .ResetToDefault();

            View.SaveButtonClicked += (name, newName, coefficients) =>
            {
                var func = Model.GetFunctionByName(name);
                Model.AddFunction(newName, func.StringRepresentation, func.Func, func.GetType(), func.Coefficients);
            };

            View.SelectedFunctionChanged += name => Model.CurrentFunction = Model.GetFunctionByName(name);

            View.ParameterUpDownsChanged += downs =>
            {
                foreach (var upDown in downs)
                {
                    var index = upDown.CoefficientIndex;
                    upDown.ValueChanged +=
                        value =>
                        {
                            Model.CurrentFunction.Coefficients[index] = (int) value;
                            Model.CurrentFunction.CalculateResult();
                        };
                }
            };
        }


    }
}
