using App.Common.Data.Runtime;
using App.Common.Utilities.Utility.Runtime;

namespace App.Core.Army.Runtime.Data
{
    public class ArmyDataLoader
    {
        private readonly IDataManager m_DataManager;

        public ArmyDataLoader(IDataManager dataManager)
        {
            m_DataManager = dataManager;
        }

        public Optional<ArmyData> Load()
        {
            var data = m_DataManager.GetData<ArmyData>(ArmyData.DataName);
            return data;
        }
    }
}