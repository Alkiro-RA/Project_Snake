using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Projekt_Snake
{
    public class XmlSerializer<T> : ISerialize<T>
    {
        private string _path;
        public XmlSerializer(string path)
        {
            _path = path;
        }
        public void Serialize(List<T> list)
        {
            Console.WriteLine("XML Serialization started.");
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            try
            {
                using TextWriter tw = new StreamWriter(_path);
                serializer.Serialize(tw, list);
            }
            catch (Exception e)
            {
                Console.WriteLine("XML Serialization failed.");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("XML Serialization finished.");
        }
        public List<T> Deserialize()
        {
            Console.WriteLine("XML Deserialization started.");
            XmlSerializer derializer = new XmlSerializer(typeof(List<T>));
            List<T> result = null;
            try
            {
                if (!File.Exists(Path))
                {
                    var file = File.Create(Path);
                    file.Close();
                }
                using TextReader tr = new StreamReader(Path);
                var obj = derializer.Deserialize(tr);
                if (obj is List<T>)
                {
                    result = (List<T>)obj;
                }
                Console.WriteLine("XML Deserialization finished.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Serialization Exception: Missing file.\n" +
                                  "Created XML file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("XML Deserialization failed.");
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public string Path
        {
            get => _path;
            set => _path = value;
        }//properties
    }
}
