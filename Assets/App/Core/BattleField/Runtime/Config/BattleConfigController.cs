using System;
using System.Collections.Generic;
using App.Common.Configs.Runtime;
using App.Common.Logger.Runtime;

namespace App.Core.BattleField.Runtime.Config
{
    public class BattleConfigController
    {
        private readonly IConfigLoader m_ConfigLoader;
        private BattleConfig m_BattleConfig;

        public BattleConfigController(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }

        public void Initialize()
        {
            var loader = new BattleConfigLoader(m_ConfigLoader);
            var dto = loader.Load();
            if (!dto.HasValue)
            {
                return;
            }

            m_BattleConfig = new BattleConfig(dto.Value);
        }

        public int GetWidth() => m_BattleConfig.Width;
        public int GetHeight() => m_BattleConfig.Height;
        public IReadOnlyList<BattleInfoConfig> GetBattles() => m_BattleConfig.Battles;
        public IReadOnlyList<int> GetUnitPositions(int unitsCount)
        {
            var index = unitsCount - 1;
            if (index < 0 || index >= m_BattleConfig.UnitPositions.Length)
            {
                HLogger.LogError("Invalid units count: " + unitsCount);
                return Array.Empty<int>();
            }
            
            return m_BattleConfig.UnitPositions[index];
        }
    }
}
