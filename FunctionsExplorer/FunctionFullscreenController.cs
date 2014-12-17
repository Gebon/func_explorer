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
