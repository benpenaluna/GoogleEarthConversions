using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public interface TimePrimative : IKMLFormat
    {
        public string Id { get; set; }
        public string TargetId { get; set; }
        IWhen When { get; set; }
    }
}
