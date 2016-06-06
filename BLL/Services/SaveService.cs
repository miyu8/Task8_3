// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentService.cs" company="">
//   
// </copyright>
// <summary>
// Student service class for adding layer between UI and DAL
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BLL
{
	using System;
	using System.Collections.Generic;
	using DAL;
    using LifeService;
    using ServerImage;
    using System.Runtime.Serialization;

    [DataContract]
    public class SaveService : IService
	{
        public SaveService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IUnitOfWork unitOfWork { get; set; }



        public void Add(GameImage gameImage)
        {
            try
            {
                if (unitOfWork.Repository<SaveImage>().GetById(gameImage.SaveId) != null)
                {
                    Update(gameImage);
                    return;
                }
                SaveImage saveImage = new SaveImage() { Type = gameImage.Type, SizeX = gameImage.SizeX, SizeY = gameImage.SizeY, Iteration = gameImage.Iteration };
                unitOfWork.Repository<SaveImage>().Add(saveImage);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
                    public void Update(GameImage gameImage)
        {
            try
            {
                SaveImage saveImage = unitOfWork.Repository<SaveImage>().GetById(gameImage.SaveId);
                saveImage.Type = gameImage.Type;
                saveImage.SizeX = gameImage.SizeX;
                saveImage.SizeY = gameImage.SizeY;
                saveImage.Iteration = gameImage.Iteration;
                unitOfWork.Repository<SaveImage>().Update(saveImage);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        } 

    public void Delete(int id)
    {
        try
        {
            IRepository<SaveImage> repo = unitOfWork.Repository<SaveImage>();
                SaveImage game = null;

            if (repo != null)
            {
                game = unitOfWork.Repository<SaveImage>().GetById(id);
            }

            if (game != null)
            {
                    repo.Delete(game);
            }

            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

        public IEnumerable<SaveService> GetAll()
        {
            return unitOfWork.Repository<SaveService>().GetAll();
        }

        public SaveService GetById(int id)
        {
            return unitOfWork.Repository<SaveService>().GetById(id);
        }

	}
}