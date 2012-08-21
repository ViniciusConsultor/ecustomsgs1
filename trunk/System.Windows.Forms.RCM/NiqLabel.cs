using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Niq.Msd.Layout
{
    public partial class NiqLabel : Label, ITranslate
    {
        private string _key = "label";

        public NiqLabel()
        {
            InitializeComponent();
        }

        #region Implementation of ITranslate

        public void AdjustLanguage(object language)
        {
            throw new NotImplementedException();
        }

        [Category("Niq Prop")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        #endregion
    }
}
