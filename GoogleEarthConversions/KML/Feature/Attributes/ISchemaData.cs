using GoogleEarthConversions.Core.Common;
using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface ISchemaData : IKMLFormat
    {
        IHref SchemaUrl { get; set; }
        ICollection<ISimpleData> SimpleData { get; set; }
    }
}
