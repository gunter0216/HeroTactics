using System.Collections.Generic;
using App.Common.Logger.Runtime;
using App.Core.Army.Runtime.Config;
using App.Core.Army.Runtime.Data;
using App.Menu.UI.External;

namespace App.Core.Army.Runtime
{
    public class ArmyUnitsService
    {
        private readonly ArmyConfigController m_ConfigController;
        private readonly ArmyDataController m_DataController;
        private readonly IUnitsController m_UnitsController; 
        
        private ArmyUnit[] m_ArmyUnits;

        public ArmyUnitsService(
            ArmyConfigController configController, 
            ArmyDataController dataController, 
            IUnitsController unitsController)
        {
            m_ConfigController = configController;
            m_DataController = dataController;
            m_UnitsController = unitsController;
        }
        
        public void Initialize()
        {
            CreateStartArmyIfNeeded();
        }

        private void CreateStartArmyIfNeeded()
        {
            if (!m_DataController.IsArmyEmpty())
            {
                return;
            }

            var startUnitsConfig = m_ConfigController.GetStartUnits();
            for (int i = 0; i < startUnitsConfig.Count; ++i)
            {
                var config = startUnitsConfig[i];
                var unit = m_UnitsController.CreateUnit(config.Key);
                if (!unit.HasValue)
                {
                    HLogger.LogError("cant create unit with key " + config.Key);
                    continue;
                }

                var data = new ArmyUnitData()
                {
                    Reference = unit.Value.Reference
                };
                
                m_DataController.SetUnitInSlot(data, i);
            }
        }

        public IReadOnlyList<ArmyUnit> GetArmyUnits()
        {
            var dataArmy = m_DataController.GetArmyUnits();
            var army = new List<ArmyUnit>();
            for (int i = 0; i < dataArmy.Count; ++i)
            {
                var data = dataArmy[i];
                if (data == null)
                {
                    continue;
                }
                
                var unit = m_UnitsController.GetUnit(data.Reference);
                if (!unit.HasValue)
                {
                    HLogger.LogError("cant find unit with reference " + data.Reference);
                    continue;
                }
                
                var armyUnit = new ArmyUnit(unit.Value, i);
                army.Add(armyUnit);
            }
            
            return army;
        }
    }
}