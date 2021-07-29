using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public interface INetworkLinkControl : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }

        GenericKML<double> MinRefreshPeriod { get; set; }
        GenericKML<double> MaxSessionLength { get; set; }
        GenericKML<string> Cookie { get; set; }
        GenericKML<string> Message { get; set; }
        GenericKML<string> LinkName { get; set; }
        GenericKML<string> LinkDescription { get; set; }
        ILinkSnippet LinkSnippet { get; set; }
        GenericKML<ITimeSpanDateTime> Expires { get; set; }
        GenericKML<NetworkLinkControlUpdate> Update { get; set; }
        AbstractView.AbstractView AbstractView { get; set; }
    }
}
