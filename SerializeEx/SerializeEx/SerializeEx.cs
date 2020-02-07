namespace SerializeXML
{
    using System.IO;
    using System.Xml.Serialization;

    public class SerializeEx
    {
        public static void Serialization(object obj, string savepath)
        {
            // if you use Network driver location, this implementation to solve the permission problems. (backup and remove works)
            if (File.Exists(savepath))
                File.Move(savepath, savepath + ".bak");
            using (StreamWriter wr = new StreamWriter(savepath))
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                xs.Serialize(wr, obj);
            }
            if (File.Exists(savepath + ".bak"))
                File.Delete(savepath + ".bak");
        }

        public static T DeSerialization<T>(string savepath)
        {
            T obj;
            using (var reader = new StreamReader(savepath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                obj = (T)xs.Deserialize(reader);
            }
            return obj;
        }
    }
}
