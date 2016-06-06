using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL;
using DAL.EntityFramework.Transaction;
using Life.Interface;
using Life.Initialization;
using LifeService;
using ServerImage;
using System.Threading;

namespace LifeServiceLib
{
	public class LifeService : ILifeService
	{
		private readonly SaveService saveService;

        public LifeService()
		{
			try
			{
                saveService = new SaveService(new UnitOfWork(new DataContext()));
            }
			catch (Exception ex)
			{
                throw;
            }
		}

        public bool Save(GameImage gameImage)
        {
            try
            {
                saveService.Add(gameImage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

		public SaveService GetStudentById(int id)
		{
			try
			{
				return saveService.GetById(id);
			catch (Exception ex)
			{
                throw;
            }
		}

        public List<SaveService> GetAllSave()
        {
            try
            {
                return saveService.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void StartNewGame(int type, Options newOptions)
        {
            Thread gameThread = new Thread(() =>
            {
                Move move = new Move(type, newOptions);
                move.RunNew();
                move.Begin();
            });
            gameThread.Start();


        }
    }
}