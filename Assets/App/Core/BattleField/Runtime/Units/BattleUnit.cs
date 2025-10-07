using App.Core.Army.Runtime;

namespace App.Core.BattleField.Runtime.Units
{
    public class BattleUnit
    {
        private readonly ArmyUnit m_Unit;

        public ArmyUnit Unit => m_Unit;

        public BattleUnit(ArmyUnit unit)
        {
            m_Unit = unit;
        }
    }
}