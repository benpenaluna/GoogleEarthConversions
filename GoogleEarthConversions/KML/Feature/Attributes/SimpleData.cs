using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class SimpleData : ISimpleData
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SimpleData(string name = "", string value = "")
        {
            Name = name;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(SimpleData) && Equals((SimpleData)obj);
        }

        protected bool Equals(SimpleData other)
        {
            return Equals(Name, other.Name) &&
                   Equals(Value, other.Value);
        }

        public static bool operator ==(SimpleData a, SimpleData b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(SimpleData a, SimpleData b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Value == string.Empty)
                return string.Empty;
            
            return string.Format("<{0} {1}=\"{2}\">{3}</{0}>", nameof(SimpleData), 
                                                               nameof(Name).ConvertFirstCharacterToLowerCase(),
                                                               Name,
                                                               Value);
        }
    }
}
