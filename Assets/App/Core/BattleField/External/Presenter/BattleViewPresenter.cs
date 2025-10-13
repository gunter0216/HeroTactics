using App.Core.BattleField.External.Fabric;
using App.Core.BattleField.External.View;
using App.Core.BattleField.External.View.Field;
using UnityEngine;

namespace App.Core.BattleField.External.Presenter
{
    public class BattleViewPresenter
    {
        private readonly BattleViewCreator m_ViewCreator;

        private BattleView m_View;
        
        public BattleViewPresenter(BattleViewCreator viewCreator)
        {
            m_ViewCreator = viewCreator;
        }

        public bool Initialize()
        {
            if (!CreateView())
            {
                return false;
            }

            return true;
        }

        private bool CreateView()
        {
            var view = m_ViewCreator.Create();
            if (!view.HasValue)
            {
                return false;
            }

            m_View = view.Value;
            return true;
        }
        
        public Vector2 GetPositionForUnit(int rowIndex, int columnIndex)
        {
            return m_View.FieldView.GetPosition(rowIndex, columnIndex);
        }
        
        public FieldView GetFieldView()
        {
            return m_View.FieldView;
        }
    }
}