using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Model;

namespace App.Core.BattleField.External.Battle
{
    public class Battle
    {
        private readonly BattleData m_Data;
        private readonly BattleConfig m_Config;

        public Battle(BattleConfig config, BattleData data)
        {
            m_Config = config;
            m_Data = data;
        }
        
        public List<BattleUnitPresenter> Units
        {
            get => m_Data.Units;
            set => m_Data.Units = value;
        }

        public Matrix<TilePresenter> Matrix
        {
            get => m_Data.Matrix;
            set => m_Data.Matrix = value;
        }

        public Matrix<int> CollidersMatrix
        {
            get => m_Data.CollidersMatrix;
            set => m_Data.CollidersMatrix = value;
        }

        public Matrix<int> LiMatrix
        {
            get => m_Data.LiMatrix;
            set => m_Data.LiMatrix = value;
        }
        
        public int Round
        {
            get => m_Data.Round;
            set => m_Data.Round = value;
        }
        
        public List<BattleUnitPresenter> RoundUnits
        {
            get => m_Data.RoundUnits;
            set => m_Data.RoundUnits = value;
        }
    }
}