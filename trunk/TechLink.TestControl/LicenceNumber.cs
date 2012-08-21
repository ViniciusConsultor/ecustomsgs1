using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Niq.Msd.Base;

namespace Niq.Msd.Test
{
    [Serializable]
    public class LicenceNumber : IObjectData
    {
        public LicenceNumber(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
        public string ToName()
        {
            return Text;
        }
    }
}
