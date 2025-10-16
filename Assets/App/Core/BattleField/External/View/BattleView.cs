using App.Core.BattleField.External.View.Field;
using App.Core.BattleField.External.View.Round;
using UnityEngine;

namespace App.Core.BattleField.External.View
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private FieldView m_FieldView;
        [SerializeField] private RoundView m_RoundView;

        public FieldView FieldView => m_FieldView;
        public RoundView RoundView => m_RoundView;
    }
}