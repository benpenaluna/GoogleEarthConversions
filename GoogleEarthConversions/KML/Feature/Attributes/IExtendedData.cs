using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface IExtendedData : IKMLFormat
    {
        IList<IData> Data { get; set; }
        ISchemaData SchemaData { get; set; }
    }
}
