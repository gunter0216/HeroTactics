using App.Core.Field.External.View;
using UnityEngine;

namespace App.Core.BattleField.External.View
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private FieldView m_FieldView;

        public FieldView FieldView => m_FieldView;
    }
}