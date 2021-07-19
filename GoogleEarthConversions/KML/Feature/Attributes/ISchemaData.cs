using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface ISchemaData : IKMLFormat
    {
        IHref SchemaUrl { get; set; }
        ICollection<ISimpleData> SimpleData { get; set; }
    }
}
