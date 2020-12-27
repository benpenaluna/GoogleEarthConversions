using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public interface IOption : IKMLFormat
    {
        OptionName Name { get; }
        bool Enabled { get; set; }
    }
}
