using System;
using App.Common.Configs.Runtime;
using App.Common.DataContainer.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Units.Runtime;
using App.Core.Units.Runtime.Config;
using App.Core.Units.Runtime.Data;
using App.Core.Units.Runtime.Model;
using App.Core.Units.Runtime.Services;

namespace App.Core.Units.External
{
    public class UnitsController : IInitSystem, IDisposable, IUnitsController
    {
        private readonly IConfigLoader m_ConfigLoader;
        private readonly IContainersDataManager m_ContainersDataManager;
        
        private UnitsConfigController m_ConfigController;
        private UnitsDataController m_DataController;
        private UnitsService m_UnitsService;
        
        public UnitsController(IConfigLoader configLoader, IContainersDataManager containersDataManager)
        {
            m_ConfigLoader = configLoader;
            m_ContainersDataManager = containersDataManager;
        }

        public void Init()
        {
            m_ConfigController = new UnitsConfigController(m_ConfigLoader);
            m_ConfigController.Initialize();

            m_DataController = new UnitsDataController(m_ContainersDataManager);
            m_DataController.Initialize();

            m_UnitsService = new UnitsService(m_ConfigController, m_DataController);
            m_UnitsService.Initialize();
        }
        
        public Optional<Unit> CreateUnit(string key)
        {
            return m_UnitsService.CreateUnit(key);
        }
        
        public void RemoveUnit(Unit unit)
        {
            m_UnitsService.RemoveUnit(unit);
        }

        public Optional<Unit> GetUnit(DataReference dataReference)
        {
            return m_UnitsService.GetUnit(dataReference);
        }

        public Optional<UnitConfig> GetUnitConfig(string key)
        {
            return m_ConfigController.GetUnitConfig(key);
        }

        public void Dispose()
        {
        }
    }
}