using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FunctionsExplorer.Functions;

namespace FunctionsExplorer
{
    class FunctionFullscreenController
    {
        public IView View { get; private set; }
        public FunctionFullscreenController(IView view, Model model)
        {
            View = view;
            model.Updated += View.UpdateView;
            View.UpdateView(model);
        }
    }
}
