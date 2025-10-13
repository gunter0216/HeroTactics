using UnityEngine;

namespace App.Core.BattleField.External.View.Field
{
    public class FieldRowView : MonoBehaviour
    {
        [SerializeField] private TileView[] m_TileViews;
        
        public TileView[] TileViews => m_TileViews;

        public Vector2 GetPosition(int index)
        {
            if (index < 0 || index >= m_TileViews.Length)
            {
                Debug.LogError($"Index {index} is out of bounds for TileViews array.");
                return Vector2.zero;
            }
            
            return m_TileViews[index].GetPosition();
        }
    }
}