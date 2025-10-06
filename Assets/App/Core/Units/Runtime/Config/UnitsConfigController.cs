using System.Collections.Generic;
using App.Common.Configs.Runtime;

namespace App.Core.Units.Runtime.Config
{
    public class UnitsConfigController
    {
        private readonly IConfigLoader m_ConfigLoader;
        
        private Dictionary<string, UnitConfig> m_UnitConfigs;

        public UnitsConfigController(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }
        
        public void Initialize()
        {
            var configLoader = new UnitsConfigLoader(m_ConfigLoader);
            var dto = configLoader.Load();
            if (!dto.HasValue)
            {
                return;
            }

            var units = dto.Value.Units;
            m_UnitConfigs = new Dictionary<string, UnitConfig>(units.Length);
            foreach (var unitDto in units)
            {
                var config = new UnitConfig(unitDto);
                m_UnitConfigs.Add(config.Key, config);
            }
        }
    }
}