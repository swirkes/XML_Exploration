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

            foreach (XElement element in xmlDoc.Descendants())
            {
                //Console.WriteLine(element.Name);
                if (element.Name != "key")
                {
                    continue;
                }
                
                var key = element.Value;
                Console.WriteLine($"Key is {key}.");

                key = "0major";
                Console.WriteLine($"Key is {key}");
            }

            string keyChangeMozartSonata = "/Users/swirkes/development/XML_Exploration/xmlsamples/KeyChangeMozartPianoSonata.musicxml";
            xmlDoc.Save(keyChangeMozartSonata);

        }
    }
}