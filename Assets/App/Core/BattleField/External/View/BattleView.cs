using App.Core.BattleField.External.View.Field;
using UnityEngine;

namespace App.Core.BattleField.External.View
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private FieldView m_FieldView;
        [SerializeField] private Transform m_UnitsContainer;

        public FieldView FieldView => m_FieldView;
    }
}