using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Life.Initialization
{
    public class JSON
    {
        public Options options;

        public Options GetJson()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Options));
            string json = File.ReadAllText(@"..\..\Settings.json");
            MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json));
            return (Options)js.ReadObject(stream);
        }
    }
}
