using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Question.Test
{
    public static class VerifyXML
    {
        public static  bool VerifyXMLFile(string xmlString)
        {
            try
            {
                XDocument.Load(xmlString);
                return true;
            }
            catch (XmlException)
            {
                // The XML string is not well-formed
                return false;
            }
        }
    }
}
