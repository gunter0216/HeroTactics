using System.Collections.Generic;
using App.Core.Army.Runtime.Dto;

namespace App.Core.Army.Runtime.Config
{
    public class ArmyConfig
    {
        private readonly StartArmyUnitConfig[] m_StartArmy;
        private readonly int m_MaxArmy;
        
        public IReadOnlyList<StartArmyUnitConfig> StartArmy => m_StartArmy;
        public int MaxArmy => m_MaxArmy;

        public ArmyConfig(ArmyDto armyDto)
        {
            m_StartArmy = new StartArmyUnitConfig[armyDto.StartArmy.Length];
            m_MaxArmy = armyDto.MaxArmy;
            for (int i = 0; i < armyDto.StartArmy.Length; i++)
            {
                m_StartArmy[i] = new StartArmyUnitConfig(armyDto.StartArmy[i]);
            }
        }
    }
}
