using App.Common.DataContainer.Runtime;
using App.Core.Units.Runtime.Config;
using App.Core.Units.Runtime.Data;

namespace App.Core.Units.Runtime.Model
{
    public class Unit
    {
        private readonly UnitData m_Data;
        private readonly UnitConfig m_Config;
        private readonly DataReference m_DataReference;

        public UnitData Data => m_Data;
        public UnitConfig Config => m_Config;

        public DataReference Reference => m_DataReference;

        public Unit(UnitConfig config, UnitData data, DataReference dataReference)
        {
            m_Config = config;
            m_Data = data;
            m_DataReference = dataReference;
        }
    }
}