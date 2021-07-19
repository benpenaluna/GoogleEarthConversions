using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface IExtendedData : IKMLFormat
    {
        IList<IData> Data { get; set; }
        ISchemaData SchemaData { get; set; }
    }
}
