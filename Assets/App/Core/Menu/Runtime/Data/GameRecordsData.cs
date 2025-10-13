using System;
using System.Collections.Generic;
using App.Common.Data.Runtime;
using Newtonsoft.Json;

namespace App.Core.Menu.Runtime.Data
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class GameRecordsData : IData, IGameRecordsData
    {
        [JsonProperty("GameRecords")] private List<GameRecord> m_GameRecords;
        
        public List<GameRecord> GameRecords
        {
            get => m_GameRecords;
            set => m_GameRecords = value;
        }
        
        public string Name()
        {
            return nameof(GameRecordsData);
        }
    }
}