using App.Core.Army.Runtime.Dto;

namespace App.Core.Army.Runtime.Config
{
    public class StartArmyUnitConfig
    {
        private readonly string m_Key;

        public string Key => m_Key;
        
        public StartArmyUnitConfig(StartArmyUnitDto startArmyUnitDto)
        {
            m_Key = startArmyUnitDto.Key;
        }
    }
}