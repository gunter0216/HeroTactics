using System;
using Newtonsoft.Json;

namespace App.Core.Units.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class UnitsDto
    {
        [JsonProperty("units")] private UnitDto[] m_Units;

        public UnitDto[] Units => m_Units;
    }
}