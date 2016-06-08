using System.Collections.Generic;
using Life.LivingProperty;
using Life.Models;
using Life.Interface;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Life.Gaming
{
    [DataContract]
    public abstract class GameBase:IGame
    {
        [DataMember]
        public int iteration;
        [DataMember]
        public int[] ValueCells = new int[6];
        [DataMember]
        public int Type { get; protected set; }
        [DataMember]
        public Cell[,] gameField { get; set; }
        [DataMember]
        public Cell[,] gameFieldNext { get; set; }
        [DataMember]
        public List<Cell[,]> ListgameField = new List<Cell[,]>();
        [DataMember]
        public GameProperty gameProperty { get; set; }
        [DataMember]
        public GenerateRandom generaterandom = new GenerateRandom();

        [OperationContract]
        public abstract void InitRnd();
        [OperationContract]
        public bool Step()
        {
            gameFieldNext = new Cell[gameProperty.SizeX, gameProperty.SizeY];
            for (int i = 0; i < gameProperty.SizeX; i++)
                for (int j = 0; j < gameProperty.SizeY; j++)
                    if (gameField[i, j] != null)
                        gameFieldNext = gameField[i, j].Living.NextGeneration(gameField, gameFieldNext);

            if (!(TestOnZero() && TestOnRepetition()))
                return false;
            iteration++;
            int typeGame = ValueCells[0];
            ValueCells = new int[6];
            ValueCells[0] = typeGame;
            for (int i = 0; i < gameProperty.SizeX; i++)
                for (int j = 0; j < gameProperty.SizeY; j++)
                    if (gameFieldNext[i, j] != null)
                        ValueCells[(int)gameFieldNext[i, j].livingName]++;

            gameField = gameFieldNext;
            gameFieldNext = null;
            ListgameField.Add(gameField);
            return true;
        }
        [OperationContract]
        public bool TestOnZero()
        {
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameFieldNext[i, j] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        [OperationContract]
        public bool Comparison(Cell[,] item)
        {
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameFieldNext[i, j] == null && item[i, j] != null || gameFieldNext[i, j] != null && item[i, j] == null ||
                        item[i, j] != null && gameFieldNext[i, j] != null && gameFieldNext[i, j].livingName != item[i, j].livingName)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        [OperationContract]
        public bool TestOnRepetition()
        {
            foreach (var item in ListgameField)
                if (Comparison(item))
                    return false;
            return true;
        }
    }
}

