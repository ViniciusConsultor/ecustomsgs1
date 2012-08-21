using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niq.Msd.Layout
{
    public interface ITranslate
    {
        void AdjustLanguage(object language);
        string Key { get; set; }
    }
}
