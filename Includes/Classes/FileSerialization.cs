using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OneClickZip.Includes.Classes
{
    public class FileSerialization
    {

        public enum Serialization
        {
            BinarySerialization = 1,
            XmlSerialization = 2,
            JsonSerialization = 3,
        }
        public static void SaveObjectToFile<T>(Serialization serialization, string filePath, T objectToSave)
        {
            Directory.CreateDirectory(filePath.Substring(0, filePath.LastIndexOf('\\')));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                switch (serialization)
                {
                    case Serialization.XmlSerialization: //Object type must have a parameterless constructor
                        XmlSerializer formatter = new XmlSerializer(typeof(T));
                        //Use the [XmlIgnore] attribute to exclude a public property or variable from being written to the file.(in XML Serialization only)
                        formatter.Serialize(writer, objectToSave);
                        break;
                    case Serialization.JsonSerialization: //Object type must have a parameterless constructor
                        var contentsToWriteToFile = Newtonsoft.Json.JsonConvert.SerializeObject(objectToSave);
                        //[JsonIgnore] attribute to exclude a public property or variable from being written to the file.
                        writer.Write(contentsToWriteToFile);
                        break;
                    case Serialization.BinarySerialization:
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        //decorate class (and all classes that it contains) with a [Serializable] attribute.Use the [NonSerialized] attribute to exclude a variable from being written to the file;
                        binaryFormatter.Serialize(writer.BaseStream, objectToSave);
                        break;
                }
            }
        }
        public static T LoadObjectToFile<T>(Serialization serialization, string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                switch (serialization)
                {
                    case Serialization.XmlSerialization:
                        XmlSerializer formatter = new XmlSerializer(typeof(T));
                        return (T)formatter.Deserialize(reader);
                    case Serialization.JsonSerialization:
                        var fileContents = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fileContents);
                    case Serialization.BinarySerialization:
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        return (T)binaryFormatter.Deserialize(reader.BaseStream);
                    default:
                        throw new System.ArgumentOutOfRangeException("Serialization = " + Convert.ToString(serialization));
                }
            }
        }


    }
}
