using System;
using System.Linq;
using System.Xml.Linq;

namespace XML_Exploration
{
    class Program
    {
        static void Main()
        {
            string filepath = "/Users/swirkes/development/XML_Exploration/xmlsamples/MozartPianoSonata.musicxml";
            XDocument mozartSonata = XDocument.Load(filepath);

            foreach (XElement element in mozartSonata.Descendants())
            {
                //Console.WriteLine(element.Name);
                if (element.Name == "key")
                {
                    var key = element.Value;
                    Console.WriteLine($"Key is {key}.");
                }
            }
            

        }
    }
}