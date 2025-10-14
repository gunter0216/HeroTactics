using System.Collections.Generic;
using App.Core.BattleField.Runtime.Dto;

namespace App.Core.BattleField.Runtime.Model
{
    public class BattleConfig
    {
        private readonly string m_Key;
        private readonly BattleUnitConfig[] m_Units;
        
        public string Key => m_Key;
        public IReadOnlyList<BattleUnitConfig> Units => m_Units;
        
        public BattleConfig(BattleDto dto)
        {
            m_Key = dto.Key;
            m_Units = new BattleUnitConfig[dto.Units.Length];
            for (int i = 0; i < dto.Units.Length; ++i)
            {
                m_Units[i] = new BattleUnitConfig(dto.Units[i]);
            }
        }
    }
}