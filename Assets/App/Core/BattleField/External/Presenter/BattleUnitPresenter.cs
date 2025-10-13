using App.Core.BattleField.Runtime.Units;
using UnityEngine;
using Vector2Int = App.Common.Algorithms.Runtime.Vector2Int;

namespace App.Core.BattleField.External.Presenter
{
    public class BattleUnitPresenter
    {
        private readonly BattleUnit m_Unit;
        private readonly Transform m_View;
        
        private Vector2Int m_Position;

        public BattleUnit Unit => m_Unit;
        public Transform View => m_View;

        public Vector2Int Position
        {
            get => m_Position;
            set => m_Position = value;
        }

        public BattleUnitPresenter(BattleUnit unit, Transform view)
        {
            m_Unit = unit;
            m_View = view;
        }
    }
}