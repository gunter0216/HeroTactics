using App.Common.Configs.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Units.Runtime.Dto;

namespace App.Core.Units.Runtime.Config
{
    public class UnitsConfigLoader
    {
        private const string m_ConfigKey = "UnitsConfig";
        
        private readonly IConfigLoader m_ConfigLoader;
        
        public UnitsConfigLoader(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }
        
        public Optional<UnitsDto> Load()
        {
            return m_ConfigLoader.LoadConfig<UnitsDto>(m_ConfigKey);
        }
    }
}