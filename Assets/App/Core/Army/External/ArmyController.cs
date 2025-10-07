using System;
using System.Collections.Generic;
using App.Common.Configs.Runtime;
using App.Common.Data.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Army.Runtime;
using App.Core.Army.Runtime.Config;
using App.Core.Army.Runtime.Data;

namespace App.Menu.UI.External
{
    public class ArmyController : IInitSystem, IDisposable
    {
        private readonly IConfigLoader m_ConfigLoader;
        private readonly IDataManager m_DataManager;
        private readonly IUnitsController m_UnitsController;
        
        private ArmyConfigController m_ConfigController;
        private ArmyDataController m_DataController;
        private ArmyUnitsService m_UnitsService; 
        
        public ArmyController(IConfigLoader configLoader, IDataManager dataManager, IUnitsController unitsController)
        {
            m_ConfigLoader = configLoader;
            m_DataManager = dataManager;
            m_UnitsController = unitsController;
        }

        public void Init()
        {
            m_ConfigController = new ArmyConfigController(m_ConfigLoader);
            m_ConfigController.Initialize();

            m_DataController = new ArmyDataController(m_DataManager);
            m_DataController.Initialize();
            
            m_UnitsService = new ArmyUnitsService(m_ConfigController, m_DataController, m_UnitsController);
            m_UnitsService.Initialize();
        }

        public IReadOnlyList<ArmyUnit> GetArmyUnits()
        {
            return m_UnitsService.GetArmyUnits();
        }

        public void Dispose()
        {
        }
    }
}