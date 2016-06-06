using System.ServiceModel;
using Life.Gaming;
using System.Runtime.Serialization;
using Life.Initialization;

namespace LifeServiceLib
{
    [ServiceContract]
	public interface ILifeService//<Options>
	{

        [OperationContract]
        Game1 Game1New(Options options);
        [OperationContract]
        Game2 Game2New(Options options);
        [OperationContract]
        Game3 Game3New(Options options);
        [OperationContract]
        Game4 Game4New(Options options);
        [OperationContract]
        void RunSave(Options options,int id, int iteration, GameBase igame);
        [OperationContract]
        void RunNew(GameBase igame);
        [OperationContract]
        void End(GameBase igame);
        [OperationContract]
        void IsData(bool[] boolMenu);
        [OperationContract]
        bool Step(GameBase igame);
        [OperationContract]
        void Remove(int id);
        //[OperationContract]
        //bool Save(GameImage gameImage);

        //[OperationContract]
        //      SaveService GetStudentById(int id);

        //[OperationContract]
        //List<SaveService> GetAllSave();
        //      [OperationContract]
        //      void StartNewGame(int type, Options newOptions);
    }
}
