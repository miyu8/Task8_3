using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using LifeService;
using ServerImage;
using LifeServiceLib;
using BLL;
using Life.Initialization;

namespace LifeServiceLib
{
	[ServiceContract]
	public interface ILifeService
	{
		[OperationContract]
		bool Save(GameImage gameImage);

		[OperationContract]
        SaveService GetStudentById(int id);

		[OperationContract]
		List<SaveService> GetAllSave();
        [OperationContract]
        void StartNewGame(int type, Options newOptions);
    }
}
