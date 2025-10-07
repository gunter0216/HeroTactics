using App.Menu.UI.External.Model;

namespace App.Core.Army.Runtime
{
    public class ArmyUnit
    {
        private readonly Unit m_Unit;
        private readonly int m_Position;

        public Unit Unit => m_Unit;
        public int Position => m_Position;

        public ArmyUnit(Unit unit, int position)
        {
            m_Unit = unit;
            m_Position = position;
        }
    }
}