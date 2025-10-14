using App.Core.BattleField.Runtime.Dto;

namespace App.Core.BattleField.Runtime.Model
{
    public class BattleConfig
    {
        private readonly string m_Key;
        
        public string Key => m_Key;
        
        public BattleConfig(BattleInfoDto dto)
        {
            m_Key = dto.Key;
        }
    }
}