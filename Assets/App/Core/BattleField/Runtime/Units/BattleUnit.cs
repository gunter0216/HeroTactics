using App.Core.Army.Runtime;
using App.Core.Army.Runtime.Units;
using App.Core.Units.Runtime.Config;

namespace App.Core.BattleField.Runtime.Units
{
    public class BattleUnit
    {
        private readonly BattleUnitData m_Data;
        private readonly UnitConfig m_Config;

        public BattleUnitData Data => m_Data;

        public UnitConfig Config => m_Config;

        public BattleUnit(BattleUnitData data, UnitConfig config)
        {
            m_Data = data;
            m_Config = config;
        }
    }
}