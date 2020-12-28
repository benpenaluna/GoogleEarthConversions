namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public interface IViewerOptions : IKMLFormat
    {
        bool HistoricalimageryEnabled { get; set; }
        bool SunlightEnabled { get; set; }
        bool StreetviewEnabled { get; set; }
    }
}
