using App.Common.Algorithms.Runtime;

namespace App.Core.BattleField.Runtime.Units
{
    public class BattleUnitData
    {
        private Vector2Int m_Position;

        public Vector2Int Position
        {
            get => m_Position;
            set => m_Position = value;
        }
    }
}