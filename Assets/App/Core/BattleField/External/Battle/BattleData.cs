using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Core.BattleField.External.Presenter;

namespace App.Core.BattleField.External.Battle
{
    public class BattleData
    {
        private List<BattleUnitPresenter> m_Units;
        private Matrix<TilePresenter> m_Matrix;
        private Matrix<int> m_CollidersMatrix;
        private Matrix<int> m_LiMatrix;
        private int m_Round;
        private List<BattleUnitPresenter> m_RoundUnits;

        public List<BattleUnitPresenter> Units
        {
            get => m_Units;
            set => m_Units = value;
        }

        public Matrix<TilePresenter> Matrix
        {
            get => m_Matrix;
            set => m_Matrix = value;
        }

        public Matrix<int> CollidersMatrix
        {
            get => m_CollidersMatrix;
            set => m_CollidersMatrix = value;
        }

        public Matrix<int> LiMatrix
        {
            get => m_LiMatrix;
            set => m_LiMatrix = value;
        }

        public int Round
        {
            get => m_Round;
            set => m_Round = value;
        }

        public List<BattleUnitPresenter> RoundUnits
        {
            get => m_RoundUnits;
            set => m_RoundUnits = value;
        }
    }
}