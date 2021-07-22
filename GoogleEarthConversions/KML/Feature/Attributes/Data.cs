using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Data : IData
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }

        public Data(string name, string value = "", string displayName = "")
        {
            Name = name;
            DisplayName = displayName;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Data) && Equals((Data)obj);
        }

        protected bool Equals(Data other)
        {
            return Equals(Name, other.Name) &&
                   Equals(DisplayName, other.DisplayName) &&
                   Equals(Value, other.Value);
        }

        public static bool operator ==(Data a, Data b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Data a, Data b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            return string.Format("<{0}{1}>{2}<{3}>{4}</{3}></{0}>", nameof(Data),
                                                                   ConvertNameToKML(),
                                                                   ConvertDisplayNameToKML(),
                                                                   nameof(Value).ConvertFirstCharacterToLowerCase(),
                                                                   Value);
        }

        private string ConvertNameToKML()
        {
            return Name == string.Empty ? string.Empty : string.Format(" {0}=\"{1}\"", nameof(Name).ConvertFirstCharacterToLowerCase(), Name);
        }

        private string ConvertDisplayNameToKML()
        {
            return DisplayName == string.Empty ? string.Empty : string.Format("<{0}>{1}</{0}>", nameof(DisplayName).ConvertFirstCharacterToLowerCase(), DisplayName);
        }
    }
}
