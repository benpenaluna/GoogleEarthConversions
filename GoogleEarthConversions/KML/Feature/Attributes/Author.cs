using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Author : IAuthor
    {
        public string Name { get; set; }

        public Author(string name = "")
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Author) && Equals((Author)obj);
        }

        protected bool Equals(Author other)
        {
            return Equals(Name, other.Name);
        }

        public static bool operator ==(Author a, Author b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Author a, Author b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Name == string.Empty)
                return string.Empty;
            
            return string.Format("<atom:{0}><atom:{1}>{2}</atom:{1}></atom:{0}>", nameof(Author).ConvertFirstCharacterToLowerCase(),
                                                                                  nameof(Name).ConvertFirstCharacterToLowerCase(),
                                                                                  Name);
        }
    }
}
