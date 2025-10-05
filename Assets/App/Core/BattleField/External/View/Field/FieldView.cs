using UnityEngine;

namespace App.Core.Field.External.View
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private FieldRowView[] m_RowViews;
        
        public FieldRowView[] RowViews => m_RowViews;
    }
}