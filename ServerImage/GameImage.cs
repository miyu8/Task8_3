using System;
using System.Runtime.Serialization;

namespace LifeService
{
    [DataContract]
    public  class GameImage
    {
        [DataMember]
        public int SaveId { get; set; }
        [DataMember]
        public int Iteration { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public int SizeX { get; set; }
        [DataMember]
        public int SizeY { get; set; }
    }
}
