namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface ISnippet : IKMLFormat
    {
        string ShortDescription { get; set; }
        int MaxLines { get; set; }
    }
}
