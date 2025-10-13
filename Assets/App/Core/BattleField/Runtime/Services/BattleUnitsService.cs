using System.Collections.Generic;
using App.Core.Army.Runtime;
using App.Core.BattleField.Runtime.Units;

namespace App.Core.BattleField.Runtime.Services
{
    public class BattleUnitsService
    {
        private readonly IArmyController m_ArmyController;

        public BattleUnitsService(IArmyController armyController)
        {
            m_ArmyController = armyController;
        }

        public List<BattleUnit> CreatePlayerBattleArmy()
        {
            var army = m_ArmyController.GetArmyUnits();
            var battleArmy = new List<BattleUnit>(army.Count);
            foreach (var armyUnit in army)
            {
                var battleUnit = new BattleUnit(armyUnit);
                battleArmy.Add(battleUnit);
            }

            return battleArmy;
        }
    }
}