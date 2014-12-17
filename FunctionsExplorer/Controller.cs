using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionsExplorer.Functions;

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
        }


    }
}
