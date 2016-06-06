using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using Life.Models;

namespace Life.Interface
{
    [ServiceContract]
    public interface IGame
    {
       // [DataMember]
       //int iteration;
       // //[DataMember]
       // public int[] ValueCells = new int[6];
       // [DataMember]
       // public int Type { get; protected set; }
       // //[DataMember]
       // public Cell[,] gameField { get; set; }
       // //[DataMember]
       // public Cell[,] gameFieldNext;
       // //[DataMember]
       // public List<Cell[,]> ListgameField = new List<Cell[,]>();
       // [DataMember]
       // public GameProperty gameProperty { get; set; }
       // [DataMember]
       // public GenerateRandom generaterandom = new GenerateRandom();
        [OperationContract]
        void InitRnd();
        [OperationContract]
        bool Step();
        [OperationContract]
        bool TestOnZero();
        [OperationContract]
        bool Comparison(Cell[,] item);
        [OperationContract]
        bool TestOnRepetition();
    }
}
