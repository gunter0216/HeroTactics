using System.Collections.Generic;
using App.Common.Configs.Runtime;

namespace App.Core.Army.Runtime.Config
{
    public class ArmyConfigController
    {
        private readonly IConfigLoader m_ConfigLoader;
        
        private ArmyConfig m_ArmyConfig;

        public ArmyConfigController(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }
        
        public void Initialize()
        {
            var configLoader = new ArmyConfigLoader(m_ConfigLoader);
            var dto = configLoader.Load();
            if (!dto.HasValue)
            {
                return;
            }
            
            m_ArmyConfig = new ArmyConfig(dto.Value);
        }
        
        public IReadOnlyList<StartArmyUnitConfig> GetStartUnits()
        {
            return m_ArmyConfig.StartArmy;
        }
    }
}