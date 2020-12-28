using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML
{
    public abstract class GoogleEarthObject
    {
        public string Id { get; set; }
        public string TargetId { get; set; }

        protected string OpeningTag(Type type, string googleEarthNamespace = "")
        {
            return Id == string.Empty ? string.Format("<{0}{1}>", googleEarthNamespace, type.Name) :
                                        string.Format("<{0}{1} {2}=\"{3}\">", googleEarthNamespace, type.Name, nameof(Id).ConvertFirstCharacterToLowerCase(), Id);
        }

        protected string ClosingTag(Type type, string googleEarthNamespace = "")
        {
            return string.Format("</{0}{1}>", googleEarthNamespace, type.Name);
        }
    }
}
