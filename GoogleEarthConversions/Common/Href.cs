using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public class Href : IHref
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                if (value != string.Empty && !value.IsValidUri())
                    throw new UriFormatException(string.Format("{0} must be an empty string or a valid URI.", nameof(Href)));

                _value = value;
            }
        }

        public Href(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Href) && Equals((Href)obj);
        }

        protected bool Equals(Href other)
        {
            return Equals(Value, other.Value);
        }

        public static bool operator ==(Href a, Href b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Href a, Href b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
