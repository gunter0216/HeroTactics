using App.Common.DataContainer.Runtime;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Units.Runtime.Config;
using App.Core.Units.Runtime.Data;
using App.Core.Units.Runtime.Model;

namespace App.Core.Units.Runtime.Services
{
    public class UnitsService
    {
        private readonly UnitsConfigController m_ConfigController;
        private readonly UnitsDataController m_DataController;

        public UnitsService(UnitsConfigController configController, UnitsDataController dataController)
        {
            m_ConfigController = configController;
            m_DataController = dataController;
        }
        
        public void Initialize()
        {
        }
        
        public Optional<Unit> CreateUnit(string key)
        {
            var configOpt = m_ConfigController.GetUnitConfig(key);
            if (!configOpt.HasValue)
            {
                HLogger.LogError("UnitsService: CreateUnit: can't find config for key " + key);
                return Optional<Unit>.Fail();
            }

            var data = new UnitData()
            {
                Key = key
            };
            
            var dataRefOpt = m_DataController.AddData(data);
            if (!dataRefOpt.HasValue)
            {
                HLogger.LogError("UnitsService: CreateUnit: can't add data for key " + key);
                return Optional<Unit>.Fail();
            }

            var unit = new Unit(configOpt.Value, data, dataRefOpt.Value);
            
            return Optional<Unit>.Success(unit);
        }
        
        public void RemoveUnit(Unit unit)
        {
            var data = unit.Data;
            m_DataController.RemoveData(data);
        }
        
        public Optional<Unit> GetUnit(DataReference dataReference)
        {
            var dataOpt = m_DataController.GetData(dataReference);
            if (!dataOpt.HasValue)
            {
                HLogger.LogError("UnitsService: GetUnit: can't find data for key " + dataReference);
                return Optional<Unit>.Fail();
            }
            
            var configOpt = m_ConfigController.GetUnitConfig(dataOpt.Value.Key);
            if (!configOpt.HasValue)
            {
                HLogger.LogError("UnitsService: GetUnit: can't find config for key " + dataOpt.Value.Key);
                return Optional<Unit>.Fail();
            }

            var unit = new Unit(configOpt.Value, dataOpt.Value, dataReference);
            
            return Optional<Unit>.Success(unit);
        }
    }
}