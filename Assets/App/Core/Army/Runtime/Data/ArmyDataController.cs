using System;
using System.Collections.Generic;
using App.Common.Data.Runtime;
using App.Common.Logger.Runtime;

namespace App.Core.Army.Runtime.Data
{
    public class ArmyDataController
    {
        private readonly IDataManager m_DataManager;
        
        private ArmyData m_Data;

        public ArmyDataController(IDataManager dataManager)
        {
            m_DataManager = dataManager;
        }
        
        public void Initialize()
        {
            var dataLoader = new ArmyDataLoader(m_DataManager);
            var data = dataLoader.Load();
            if (!data.HasValue)
            {
                HLogger.LogError("ArmyDataController: Army data not found!");
                return;
            }

            m_Data = data.Value;
            m_Data.Army = null; // todo
            m_Data.Army ??= Array.Empty<ArmyUnitData>();
        }
        
        public IReadOnlyList<ArmyUnitData> GetArmyUnits()
        {
            return m_Data.Army;
        }

        public bool IsArmyEmpty()
        {
            return m_Data.Army.Length <= 0;
        }

        public void SetUnitInSlot(ArmyUnitData data, int index)
        {
            if (m_Data.Army.Length < index + 1)
            {
                var previous = m_Data.Army;
                m_Data.Army = new ArmyUnitData[index + 1];
                Array.Copy(previous, m_Data.Army, previous.Length);
            }
            else if (m_Data.Army[index] != null)
            {
                HLogger.LogError("slot is not empty");
                return;
            }
            
            m_Data.Army[index] = data;
        }
    }
}