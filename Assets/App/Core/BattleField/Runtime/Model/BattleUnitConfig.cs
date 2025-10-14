using App.Core.BattleField.Runtime.Dto;

namespace App.Core.BattleField.Runtime.Model
{
    public class BattleUnitConfig
    {
        private readonly string m_Key;
        
        public string Key => m_Key;
        
        public BattleUnitConfig(BattleUnitDto dto)
        {
            m_Key = dto.Key;
        }
    }
}