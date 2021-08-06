using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public interface IXmlRetrievalElements
    {
        string ElementName { get; set; }
        IDictionary<string, string> ChildElements { get; set; }
    }
}
