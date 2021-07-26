namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface IData : IKMLFormat
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        string Value { get; set; }
    }
}
