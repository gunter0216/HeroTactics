using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Core.BattleField.External.View.Field
{
    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject m_Light;
        
        private event Action m_OnClick;  
        
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

        public void OnPointerClick(PointerEventData eventData)
        {
            m_OnClick?.Invoke();
        }
        
        public void SetClickCallback(Action callback)
        {
            m_OnClick = callback;
        }
    }
}