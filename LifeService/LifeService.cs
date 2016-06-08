using System;
using System.Linq;
using Life.Initialization;
using Life.Gaming;
using Life.BaseData;
using Life;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace LifeServiceLib
{
    [DataContract]
    //[DataContract]
    //[KnownType(typeof(Options))]
    public class LifeService : ILifeService
    {
        //Options options;//=KnownTypeAttribute.;
        public RecordBase recordBase = new RecordBase();
        DataModelContainer db;

        //public LifeService()//Options options)
        //{
        //    this.options = options;
        //}

        //public LifeService(Options options)
        //{
        //    this.options = options;
        //}
        //[OperationContract]
        public Game1 Game1New(Options options)
        {
            return new Game1(options.gameProperty);
        }

        //[OperationContract]
        public Game2 Game2New(Options options)
        {
            return new Game2(options.gameProperty, options.grass1Property);
        }
       // [OperationContract]
        public Game3 Game3New(Options options)
        {
            return new Game3(options.gameProperty, options.grass1Property);
        }
        //[OperationContract]
        public Game4 Game4New(Options options)
        {
            return new Game4(options.gameProperty, options.grass2Property, options.herbivorous1Property);
        }
        //[OperationContract]
        public void RunSave(Options options,int id, int iteration, GameBase igame)
        {
            igame.gameField = recordBase.TakeList(id, igame.ValueCells, options);
            igame.iteration = iteration;
        }
        //[OperationContract]
        public void RunNew(GameBase igame)
        {
            igame.InitRnd();
            igame.iteration = 1;
        }
       // [OperationContract]
        public void End(GameBase igame)
        {
            try
            {
                using (var db = new DataModelContainer())
                {
                    recordBase.AddList(igame.gameField, igame.Type, igame.iteration);
                }
            }
            catch (Exception ex)
            {
                recordBase.ErrorBase(ex);
            }
        }
        //[OperationContract]
        public void IsData(bool[] boolMenu)
        {
            try
            {
                using (db = new DataModelContainer())
                {
                    db.Database.CreateIfNotExists();
                    if (db.GameSet.Count() != 0)
                        boolMenu[1] = true;
                    else
                        boolMenu[1] = false;
                }
            }
            catch (Exception ex)
            {
                recordBase.ErrorBase(ex);
            }
        }
       // [OperationContract]
        public bool Step(GameBase igame)
        {
            return igame.Step();
        }

        public void Remove(int id)
        {
            recordBase.RemoveList(id);
        }
    }
    //public class LifeService : ILifeService
    //{
    //	private readonly SaveService saveService;
    //       //Form1 form;
    //      // public Life_Form.InitializationForm.Move move;
    //       public LifeService()
    //	{
    //		try
    //		{
    //               saveService = new SaveService(new UnitOfWork(new DataContext()));
    //           }
    //		catch (Exception ex)
    //		{
    //               throw;
    //           }
    //	}

    //       public bool Save(GameImage gameImage)
    //       {
    //           try
    //           {
    //               saveService.Add(gameImage);
    //               return true;
    //           }
    //           catch (Exception ex)
    //           {
    //               return false;
    //           }

    //       }

    //	public SaveService GetStudentById(int id)
    //	{
    //           try
    //           {
    //               return saveService.GetById(id);
    //           }
    //           catch (Exception ex)
    //           {
    //               throw;
    //           }
    //	}

    //       public List<SaveService> GetAllSave()
    //       {
    //           try
    //           {
    //               return saveService.GetAll().ToList();
    //           }
    //           catch (Exception ex)
    //           {
    //               throw;
    //           }
    //       }

    //       public void StartNewGame(int type, Options newOptions)
    //       {
    //           //if (form == null)
    //           //{
    //           //Thread gameThread = new Thread(() =>
    //           //{
    //           //    move = new Life_Form.InitializationForm.Move(type, form, newOptions);
    //           //    move.RunNew();
    //           //    move.Begin();
    //           //    form. Active();
    //           //});
    //           Thread gameThread = new Thread(() =>
    //               {
    //                   Move move = new Move(type, newOptions);
    //                   move.RunNew();
    //                   move.Begin();
    //               });
    //           gameThread.Start();

    //           //}
    //       }
    // }
}