namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface IAddress : IKMLFormat
    {
        string UnstructuredAddress { get; set; }
    }
}
