
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace demo
{
    public class CustomSerializer<T>
    {
        string FileName = "";
        IFormatter formatter = new BinaryFormatter();
        public CustomSerializer(string fileName)
        {
            FileName = AppDomain.CurrentDomain.BaseDirectory + fileName;
            using StreamWriter w = File.AppendText(FileName);
        }
        public void Save(List<T> obj)
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, obj);
            }
        }
        public List<T> Load()
        {
            List<T> deserialised;
            using (FileStream filestream = new FileStream(FileName, FileMode.Open))
            {
                deserialised = (List<T>)formatter.Deserialize(filestream);
            }
            return deserialised;
        }
    }
}

