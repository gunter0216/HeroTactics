namespace App.Core.BattleField.Runtime.Config
{
    public class BattleInfoConfig
    {
        private readonly string m_Key;
        
        public string Key => m_Key;
        
        public BattleInfoConfig(BattleInfoDto dto)
        {
            m_Key = dto.Key;
        }
    }
}