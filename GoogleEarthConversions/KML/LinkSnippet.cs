using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public class LinkSnippet : GenericKML<string>, ILinkSnippet
    {
        private int _maxLines;
        public int MaxLines
        {
            get => _maxLines;
            set 
            { 
                if (value <= 0)
                {
                    var message = string.Format("{0} must be greater than or equal to 1.", nameof(MaxLines));
                    throw new ArgumentOutOfRangeException(message);
                }
                                
                _maxLines = value; 
            }
        }

        public LinkSnippet(string value) : base(nameof(LinkSnippet).ConvertFirstCharacterToLowerCase(), value, string.Empty) 
        {
            MaxLines = 2;
        }

        public override string SerialiseToKML()
        {
            if (Value.ToString() == Default.ToString())
                return string.Empty;

            var maxLinesKMLString = string.Format(" {0}=\"{1}\"", nameof(MaxLines).ConvertFirstCharacterToLowerCase(), MaxLines);

            return string.Format("<{0}{1}>{2}</{0}>", KmlTagName, maxLinesKMLString, Value.ToString());
        }

        public static new LinkSnippet DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
