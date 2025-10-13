using UnityEngine;

namespace App.Core.Field.External.View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private GameObject m_Light;
        
        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public void StayLight()
        {
            m_Light.SetActive(true);
        }

        public void StayDefault()
        {
            m_Light.SetActive(false);
        }
    }
}