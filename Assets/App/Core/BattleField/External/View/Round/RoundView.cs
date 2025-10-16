using UnityEngine;

namespace App.Core.BattleField.External.View.Round
{
    public class RoundView : MonoBehaviour
    {
        [SerializeField] private RoundUnitView m_UnitViewPrefab;
        [SerializeField] private Transform m_UnitViewContainer;
        
        public RoundUnitView UnitViewPrefab => m_UnitViewPrefab;
        public Transform UnitViewContainer => m_UnitViewContainer;
    }
}