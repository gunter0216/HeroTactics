using App.Core.BattleField.Runtime.Units;
using UnityEngine;

namespace App.Battle.UI.External.Presenter
{
    public class BattleUnitPresenter
    {
        private readonly BattleUnit m_Unit;
        private readonly Transform m_View;

        public BattleUnit Unit => m_Unit;
        public Transform View => m_View;

        public BattleUnitPresenter(BattleUnit unit, Transform view)
        {
            m_Unit = unit;
            m_View = view;
        }
    }
}