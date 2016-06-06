using System.Runtime.Serialization;

namespace ServerImage
{
    [DataContract]
    public  class SaveImage
    {

            [DataMember]
            public int Type { get; set; }
            [DataMember]
            public int SizeX { get; set; }
            [DataMember]
            public int SizeY { get; set; }
            [DataMember]
            public int Iteration { get; set; }
    }
}
