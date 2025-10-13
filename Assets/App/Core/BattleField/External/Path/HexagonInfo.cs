using App.Common.Algorithms.Runtime;

namespace App.Core.BattleField.External.Path
{
    public class HexagonInfo
    {
        public readonly Vector2Int[] OddOffsets =
        {
            new Vector2Int( -1, 0 ), 
            new Vector2Int( -1, -1 ), 
            new Vector2Int( 0, -1 ), 
            new Vector2Int( 1, 0 ), 
            new Vector2Int( -1, 1 ), 
            new Vector2Int( 0, 1 )
        };
        
        public readonly Vector2Int[] EvenOffsets =
        {
            new Vector2Int( -1, 0 ), 
            new Vector2Int( 0, -1 ), 
            new Vector2Int( 1, -1 ), 
            new Vector2Int( 1, 0 ), 
            new Vector2Int( 0, 1 ), 
            new Vector2Int( 1, 1 )
        };
        
        public Vector2Int[] GetOffsets(int row)
        {
            return (row % 2 == 0) ? EvenOffsets : OddOffsets;
        }
    }
}