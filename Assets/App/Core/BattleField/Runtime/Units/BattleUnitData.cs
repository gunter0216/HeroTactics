using App.Common.Algorithms.Runtime;

namespace App.Core.BattleField.Runtime.Units
{
    public class BattleUnitData
    {
        private Vector2Int m_Position;
        private bool m_PlayerControlled;

        public Vector2Int Position
        {
            get => m_Position;
            set => m_Position = value;
        }

        public bool PlayerControlled
        {
            get => m_PlayerControlled;
            set => m_PlayerControlled = value;
        }
    }
}