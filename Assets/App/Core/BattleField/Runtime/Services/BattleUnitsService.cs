using System.Collections.Generic;
using App.Common.Algorithms.Runtime;
using App.Common.Logger.Runtime;
using App.Core.Army.Runtime;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Model;
using App.Core.BattleField.Runtime.Units;
using App.Core.Units.Runtime;

namespace App.Core.BattleField.Runtime.Services
{
    public class BattleUnitsService
    {
        private readonly IArmyController m_ArmyController;
        private readonly IUnitsController m_UnitsController;
        private readonly BattleConfigController m_ConfigController;

        public BattleUnitsService(
            IArmyController armyController, 
            BattleConfigController configController, 
            IUnitsController unitsController)
        {
            m_ArmyController = armyController;
            m_ConfigController = configController;
            m_UnitsController = unitsController;
        }

        public List<BattleUnit> CreatePlayerBattleArmy()
        {
            var army = m_ArmyController.GetArmyUnits();
            var battleArmy = new List<BattleUnit>(army.Count);
            foreach (var armyUnit in army)
            {
                var data = new BattleUnitData();
                var config = armyUnit.Unit.Config;
                var battleUnit = new BattleUnit(data, config);
                battleArmy.Add(battleUnit);
            }

            PlaceUnits(battleArmy, 0);

            return battleArmy;
        }

        public List<BattleUnit> CreateEnemyBattleArmy(BattleConfig battleConfig)
        {
            var width = m_ConfigController.GetWidth();
            var units = battleConfig.Units;
            var battleArmy = new List<BattleUnit>(units.Count);
            foreach (var unit in units)
            {
                var data = new BattleUnitData();
                var key = unit.Key;
                var config = m_UnitsController.GetUnitConfig(key);
                if (!config.HasValue)
                {
                    HLogger.LogError("BattleUnitsService: CreateEnemyBattleArmy: can't find config for key " + key);
                    continue;
                }
                
                var battleUnit = new BattleUnit(data, config.Value);
                battleArmy.Add(battleUnit);
            }

            PlaceUnits(battleArmy, width - 1);

            return battleArmy;
        }

        private void PlaceUnits(IReadOnlyList<BattleUnit> units, int positionX)
        {
            var positions = m_ConfigController.GetUnitPositions(units.Count);
            for (int i = 0; i < units.Count; ++i)
            {
                var unit = units[i];
                var col = positions[i];
                unit.Data.Position = new Vector2Int(positionX, col);
            }
        }
    }
}