using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XML_Exploration
{
    class Program
    {
        static void Main()
        {
            string filepath = "/Users/swirkes/development/XML_Exploration/xmlsamples/MozartPianoSonata.musicxml";
            XDocument xmlDoc = XDocument.Load(filepath);

            foreach (XElement element in xmlDoc.Descendants("key"))
            {
                XElement fifthsElement = element.Element("fifths");
                if (fifthsElement != null)
                {
                    fifthsElement.Value = "0";
                }

                XElement modeElement = element.Element("mode");
                if (modeElement != null)
                {
                    modeElement.Value = "major";
                }
            }
            
            

            string keyChangeMozartSonata = "/Users/swirkes/development/XML_Exploration/xmlsamples/KeyChangeMozartPianoSonata.musicxml";
            xmlDoc.Save(keyChangeMozartSonata);
            
            Console.WriteLine("Key change applied and file saved.");
            
        }
    }
}