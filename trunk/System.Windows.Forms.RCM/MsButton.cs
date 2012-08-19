using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace System.Windows.Forms.RCM
{
    public partial class MsButton : Label
    {
        public MsButton()
        {
            InitializeComponent();
        }

        public MsButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
