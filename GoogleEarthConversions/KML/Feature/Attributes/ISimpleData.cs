namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface ISimpleData : IKMLFormat
    {
        string Name { get; set; }
        string Value { get; set; }
    }
}
