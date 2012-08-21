using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niq.Msd.Layout
{
    public interface INiqControl
    {
        object DataSource { get; set; }
        string TextField { get; set; }
        string ValueField { get; set; }

        void DataBind();
    }
}
