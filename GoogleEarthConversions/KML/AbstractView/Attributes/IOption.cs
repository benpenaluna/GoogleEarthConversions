namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public interface IOption : IKMLFormat
    {
        OptionName Name { get; set; }
        bool Enabled { get; set; }
    }
}
