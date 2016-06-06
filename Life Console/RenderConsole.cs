using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life.Models;
using System.Threading;
using Life.BaseData;
using Life.Gaming;
using Life.GameConsole;
using Life.Initialization;

namespace Life.Gaming
{
    class RenderConsole
    {
        public GameBase igame;
        public GameBaseConsole gameBaseConsole;
        public Options options;
        public TypeGameConsole typeGameConsole;
        public struct TypeGameConsole
        {
            public GameBase igame;
            public GameBaseConsole gameBaseConsole;

            public TypeGameConsole(GameBase igame, GameBaseConsole gameBaseConsole)
            {
                this.igame = igame;
                this.gameBaseConsole = gameBaseConsole;
            }
        }

        public TypeGameConsole SelectGame(int type, Options newOptions)
        {
            Console.Clear();
            options = newOptions;
            switch (type)
            {
                case 1:
                    return new TypeGameConsole(new Game1(options.gameProperty), 
                        new Game1Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name));
                case 2:
                   return  new TypeGameConsole(new Game2(options.gameProperty, options.grass1Property), 
                       new Game2Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name));
                case 3:
                    return new TypeGameConsole(new Game3(options.gameProperty, options.grass1Property), 
                        new Game3Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name));
                case 4:
                    return new TypeGameConsole(new Game4(options.gameProperty, options.grass2Property, options.herbivorous1Property), 
                        new Game4Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name));
            }
            return new TypeGameConsole(null,null);
        }

}
}
