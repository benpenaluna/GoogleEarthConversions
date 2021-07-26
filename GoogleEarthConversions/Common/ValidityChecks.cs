using System;
using System.Xml;

namespace GoogleEarthConversions.Core.Common
{
    public static class ValidityChecks
    {
        public static bool IsValidUri(this string absolutePath)
        {
            try
            {
                new Uri(absolutePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidUriFragmentName(this string fragmentName)
        {
            string uriFragmentRegEx = "#(?:[A-Za-z0-9\\-._~!$&'()*+,;=:@/?]|%[0-9A-Fa-f]{2})*";

            var result = System.Text.RegularExpressions.Regex.Match(fragmentName, uriFragmentRegEx);

            if (result.Value == fragmentName)
                return true;

            return false;
        }

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
