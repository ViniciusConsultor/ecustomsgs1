using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niq.Msd.Layout
{
    public interface INiqInputControl : INiqControl
    {
        string InputText { get; set; }
        object InputValue { get; set; }
        bool MultipleLines { get; set; }
        bool ReadOnly { get; set; }

        InputTypes InputType { get; set; }

        bool IsNullOrEmpty();
        void ShowWarning();
    }
}
