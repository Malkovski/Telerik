namespace GenerateXmlFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    class GenerateXmlFromTextEntryPoint
    {
        static void Main()
        {
            string line;
            XElement persons = new XElement("persons");

            using (StreamReader file = new StreamReader("../../persons.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var personAttributes = line.Split(',');
                    XElement person = new XElement("person",
                        new XElement("name", personAttributes[0]),
                        new XElement("address", personAttributes[1]),
                        new XElement("phone", personAttributes[2]));

                    persons.Add(person);
                }
            }

            persons.Save("../../persons.xml");
            Console.WriteLine(persons);
        }
    }
}
