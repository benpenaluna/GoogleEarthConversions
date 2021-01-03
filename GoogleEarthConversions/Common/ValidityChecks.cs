using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GoogleEarthConversions.Core.Common
{
    public static class ValidityChecks
    {
        public static bool IsValidXML(this string xml)
        {
            try
            {
                new XmlDocument().Load(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
