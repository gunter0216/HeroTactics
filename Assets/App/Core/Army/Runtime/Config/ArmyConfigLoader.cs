using App.Common.Configs.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Army.Runtime.Dto;

namespace App.Core.Army.Runtime.Config
{
    public class ArmyConfigLoader
    {
        private const string m_ConfigKey = "ArmyConfig";
        
        private readonly IConfigLoader m_ConfigLoader;
        
        public ArmyConfigLoader(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }
        
        public Optional<ArmyDto> Load()
        {
            return m_ConfigLoader.LoadConfig<ArmyDto>(m_ConfigKey);
        }
    }
}