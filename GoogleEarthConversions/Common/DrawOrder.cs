using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public class DrawOrder : IDrawOrder
    {
        public int OrderValue { get; set; }

        public DrawOrder(int orderValue = 0)
        {
            OrderValue = orderValue;
        }

        public string ConvertObjectToKML()
        {
            if (OrderValue == 0)
                return "";

            return string.Format("<gx:{0}>{1}</gx:{0}>",
                                 nameof(DrawOrder).ConvertFirstCharacterToLowerCase(),
                                 OrderValue);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(DrawOrder) && Equals((DrawOrder)obj);
        }

        protected bool Equals(DrawOrder other)
        {
            return Equals(OrderValue, other.OrderValue);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
