using System.Collections.Generic;

namespace App.Core.Menu.Runtime.Data
{
    public interface IGameRecordsData
    {
        List<GameRecord> GameRecords { get; set; }
    }
}