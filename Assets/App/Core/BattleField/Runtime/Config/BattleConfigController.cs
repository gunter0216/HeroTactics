using System;
using System.Collections.Generic;
using App.Common.Configs.Runtime;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.Runtime.Model;

namespace App.Core.BattleField.Runtime.Config
{
    public class BattleConfigController
    {
        private readonly IConfigLoader m_ConfigLoader;
        private BattlesConfig m_BattlesConfig;

        private Dictionary<string, BattleConfig> m_Battles;

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

            m_BattlesConfig = new BattlesConfig(dto.Value);
            m_Battles = new Dictionary<string, BattleConfig>(m_BattlesConfig.Battles.Count);
            foreach (var battle in m_BattlesConfig.Battles)
            {
                m_Battles[battle.Key] = battle;
            }
        }

        public int GetWidth() => m_BattlesConfig.Width;
        public int GetHeight() => m_BattlesConfig.Height;
        
        public Optional<BattleConfig> GetBattle(string key)
        {
            if (m_Battles.TryGetValue(key, out var battle))
            {
                return Optional<BattleConfig>.Success(battle);
            }

            return Optional<BattleConfig>.Fail();
        }
        
        public IReadOnlyList<int> GetUnitPositions(int unitsCount)
        {
            var index = unitsCount - 1;
            if (index < 0 || index >= m_BattlesConfig.UnitPositions.Length)
            {
                HLogger.LogError("Invalid units count: " + unitsCount);
                return Array.Empty<int>();
            }
            
            return m_BattlesConfig.UnitPositions[index];
        }
    }
}
