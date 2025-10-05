using UnityEngine;

namespace App.Core.Field.External.View
{
    public class FieldRowView : MonoBehaviour
    {
        [SerializeField] private TileView[] m_TileViews;
        
        public TileView[] TileViews => m_TileViews;
    }
}