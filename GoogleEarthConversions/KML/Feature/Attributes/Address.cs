﻿using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Address : IAddress
    {
        public string UnstructuredAddress { get; set; }

        public Address(string unStructuredAddress = "")
        {
            UnstructuredAddress = unStructuredAddress;
        }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Address) && Equals((Address)obj);
        }

        protected bool Equals(Address other)
        {
            return Equals(UnstructuredAddress, other.UnstructuredAddress);
        }

        public static bool operator ==(Address a, Address b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Address a, Address b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (UnstructuredAddress == string.Empty)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(Address).ConvertFirstCharacterToLowerCase(), UnstructuredAddress);
        }

        public static Address DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
