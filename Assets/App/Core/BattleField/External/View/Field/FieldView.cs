using UnityEngine;

namespace App.Core.Field.External.View
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private FieldRowView[] m_RowViews;
        
        public FieldRowView[] RowViews => m_RowViews;
        
        public Vector2 GetPosition(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || rowIndex >= m_RowViews.Length)
            {
                Debug.LogError($"Row index {rowIndex} is out of bounds for RowViews array.");
                return Vector2.zero;
            }
            
            var rowView = m_RowViews[rowIndex];
            return rowView.GetPosition(columnIndex);
        }
    }
}