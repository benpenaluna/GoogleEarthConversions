﻿using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public class DrawOrder : IDrawOrder
    {
        public int OrderValue { get; set; }

        public DrawOrder(int orderValue = 0)
        {
            OrderValue = orderValue;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(DrawOrder) && Equals((DrawOrder)obj);
        }

        protected bool Equals(DrawOrder other)
        {
            return Equals(OrderValue, other.OrderValue);
        }

        public static bool operator ==(DrawOrder a, DrawOrder b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(DrawOrder a, DrawOrder b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (OrderValue == 0)
                return "";

            return string.Format("<gx:{0}>{1}</gx:{0}>",
                                 nameof(DrawOrder).ConvertFirstCharacterToLowerCase(),
                                 OrderValue);
        }

        public static DrawOrder DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
