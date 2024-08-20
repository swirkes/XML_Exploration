using System.Xml.Linq;

namespace XML_Exploration
{
    class Program
    {
        static void Main()
        {
            var filepath = "/Users/swirkes/development/XML_Exploration/xmlsamples/MozartPianoSonata.musicxml";
            var xmlDoc = XDocument.Load(filepath);

            var pitchClasses = new[] { "C", "D", "E", "F", "G", "A", "B" };

            var notes = xmlDoc.Descendants("note");

            foreach (var note in notes)
            {
                var pitch = note.Element("pitch");
                if (pitch == null)
                    continue;

                var stepElement = pitch.Element("step");
                var alterElement = pitch.Element("alter");
                var octaveElement = pitch.Element("octave");
                
                if (stepElement == null || octaveElement == null)
                    continue;
                
                var step = stepElement.Value; 
                var octave = int.Parse(octaveElement.Value);
                
                var index = Array.IndexOf(pitchClasses, step);
                var newIndex = index - 5;
                
                if (newIndex < 0) 
                { 
                    newIndex += pitchClasses.Length; 
                    octave -= 1;
                }
                
                stepElement.Value = pitchClasses[newIndex]; 
                octaveElement.Value = octave.ToString();
                
                if (alterElement == null)
                    continue;

                alterElement.Value = "0";
            }

            foreach (var element in xmlDoc.Descendants("key"))
            {
                element.Element("fifths")?.SetValue("0");
                element.Element("mode")?.SetValue("major");
            }
            
            var keyChangeMozartSonata = "/Users/swirkes/development/XML_Exploration/xmlsamples/KeyChangeMozartPianoSonata.musicxml";
            xmlDoc.Save(keyChangeMozartSonata);
            
            Console.WriteLine("Key change applied and file saved.");
            
        }
    }
}