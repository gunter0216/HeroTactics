using System;
using System.Collections;
using System.Collections.Generic;
using App.Common.DataContainer.Runtime.Data;
using Newtonsoft.Json;

namespace App.Core.Units.Runtime.Data
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class UnitsContainerData : IContainerData
    {
        public static string ContainerKey => nameof(UnitsContainerData);

        [JsonProperty("data")] private List<UnitData> m_Data;

        IList IContainerData.Data => m_Data;

        public List<UnitData> Data
        {
            get => m_Data;
            set => m_Data = value;
        }

        public UnitsContainerData()
        {
            m_Data = new List<UnitData>();
        }

        public string GetContainerKey()
        {
            return ContainerKey;
        }

        public string Name()
        {
            return ContainerKey;
        }
    }
}