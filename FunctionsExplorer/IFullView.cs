using System;

namespace FunctionsExplorer
{
    public interface IFullView : IView
    {
        event Actions.ResetButtonClickedEventHandler ResetButtonClicked;
        event Actions.SaveButtonClickedEventHandler SaveButtonClicked;
        event FunctionsList.SelectedChangedEventHandler SelectedFunctionChanged;
        event ParametersView.ParameterUpDownsChangedEventHandler ParameterUpDownsChanged;
        event EventHandler OpenCurrent;

    }
}