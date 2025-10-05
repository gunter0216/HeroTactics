using System;
using Newtonsoft.Json;

namespace App.Core.Units.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class UnitDto
    {
        [JsonProperty("key")] private string m_Key;
        [JsonProperty("asset")] private string m_Asset;

        public string Key => m_Key;
        public string Asset => m_Asset;
    }
}