using System;
using System.Linq;
using Life.Initialization;
using Life.Gaming;
using Life.BaseData;

namespace Life
{
    public  class ServerInit
    {
        public Options options;
        public RecordBase recordBase = new RecordBase();
        DataModelContainer db;

        public ServerInit(Options options)
            {
            this.options = options;
            }

        public Game1 Game1New()
        {
           return new Game1(options.gameProperty);
        }

        public Game2 Game2New()
        {
            return new Game2(options.gameProperty, options.grass1Property);
        }

        public Game3 Game3New()
        {
            return new Game3(options.gameProperty, options.grass1Property);
        }

        public Game4 Game4New()
        {
            return new Game4(options.gameProperty, options.grass2Property, options.herbivorous1Property);
        }

        public void RunSave(int id, int iteration, GameBase igame)
        {
            igame.gameField = recordBase.TakeList(id, igame.ValueCells, options);
            igame.iteration = iteration;
        }

        public void RunNew(GameBase igame)
        {
            igame.InitRnd();
            igame.iteration = 1;
        }

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

        public bool Step(GameBase igame)
        {
           return igame.Step();
        }

       public void Remove(int id)
        {
            recordBase.RemoveList(id);
        }
    }
}
