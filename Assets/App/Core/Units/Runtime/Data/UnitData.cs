using System;
using Newtonsoft.Json;

namespace App.Core.Unts.Runtime.Data
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class UnitData
    {
        [JsonProperty("key")] 
        private string m_Key;

        public string Key
        {
            get => m_Key;
            set => m_Key = value;
        }
    }
}