using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace GoogleEarthConversions.Core.Common
{
    internal static class XmlOperations
    {
        public static XmlNodeList RetrieveElements(string kml, string elementName)
        {
            var doc = RetrieveXmlDocument(kml);
            
            return doc.GetElementsByTagName(elementName);
        }

        public static XmlRetrievalElements RetrieveXmlElements(string kml)
        {
            var doc = RetrieveXmlDocument(kml);

            var xmlRetrievalElements = new XmlRetrievalElements
            {
                ElementName = doc.DocumentElement.Name,
                ChildElements = RetrieveChildElements(doc)
            };

            return xmlRetrievalElements;
        }

        private static XmlDocument RetrieveXmlDocument(string kml)
        {
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(kml));
            var doc = new XmlDocument();
            doc.Load(memStream);
            memStream.Close();

            return doc;
        }

        private static IDictionary<string, string> RetrieveChildElements(XmlDocument doc)
        {
            var childElements = new Dictionary<string, string>();

            if (doc.HasChildNodes)
            {
                for (int i = 0; i < doc.ChildNodes.Count; i++)
                {
                    var elementName = doc.ChildNodes[i].Name;
                    var innerXml = doc.ChildNodes[i].InnerXml;
                    childElements.Add(elementName, innerXml);
                }
            }

            return childElements;
        }
    }
}
