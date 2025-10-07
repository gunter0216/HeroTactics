using App.Common.DataContainer.Runtime;
using App.Common.Utilities.Utility.Runtime;

namespace App.Core.Unts.Runtime.Data
{
    public class UnitsDataController
    {
        private readonly IContainersDataManager m_ContainersDataManager;

        public UnitsDataController(IContainersDataManager containersDataManager)
        {
            m_ContainersDataManager = containersDataManager;
        }
        
        public void Initialize()
        {
        }

        public Optional<DataReference> AddData(UnitData data)
        {
            return m_ContainersDataManager.AddData(UnitsContainerData.ContainerKey, data);
        }

        public Optional<DataReference> RemoveData(UnitData data)
        {
            return m_ContainersDataManager.RemoveData(UnitsContainerData.ContainerKey, data);
        }

        public Optional<UnitData> GetData(IDataReference dataReference)
        {
            return m_ContainersDataManager.GetData<UnitData>(dataReference);
        }
    }
}