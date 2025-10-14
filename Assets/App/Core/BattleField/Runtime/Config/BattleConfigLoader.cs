using App.Common.Configs.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.Runtime.Dto;

namespace App.Core.BattleField.Runtime.Config
{
    public class BattleConfigLoader
    {
        private const string m_ConfigKey = "BattlesConfig";
        private readonly IConfigLoader m_ConfigLoader;

        public BattleConfigLoader(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }

        public Optional<BattleDto> Load()
        {
            return m_ConfigLoader.LoadConfig<BattleDto>(m_ConfigKey);
        }
    }
}

