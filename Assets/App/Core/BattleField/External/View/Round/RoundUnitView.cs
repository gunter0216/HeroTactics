using UnityEngine;
using UnityEngine.UI;

namespace App.Core.BattleField.External.View.Round
{
    public class RoundUnitView : MonoBehaviour
    {
        [SerializeField] private Image m_Icon;
        [SerializeField] private GameObject m_PlayerStroke;
        [SerializeField] private GameObject m_EnemyStroke;

        public void ChangeStateToEnemy()
        {
            m_PlayerStroke.SetActive(false);
            m_EnemyStroke.SetActive(true);
        }
        
        public void ChangeStateToPlayer()
        {
            m_PlayerStroke.SetActive(true);
            m_EnemyStroke.SetActive(false);
        }
        
        public void SetIcon(Sprite sprite)
        {
            m_Icon.sprite = sprite;
        }
    }
}