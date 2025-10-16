using System.Collections.Generic;
using App.Common.SpriteLoaders.Runtime;
using App.Core.BattleField.External.Fabric;
using App.Core.BattleField.External.View;
using App.Core.BattleField.External.View.Field;
using UnityEngine;

namespace App.Core.BattleField.External.Presenter
{
    public class BattleViewPresenter
    {
        private readonly BattleViewCreator m_ViewCreator;
        private readonly ISpriteLoader m_SpriteLoader;

        private BattleView m_View;
        private RoundPresenter m_RoundPresenter;
        
        public BattleViewPresenter(BattleViewCreator viewCreator, ISpriteLoader spriteLoader)
        {
            m_ViewCreator = viewCreator;
            m_SpriteLoader = spriteLoader;
        }

        public bool Initialize()
        {
            if (!CreateView())
            {
                return false;
            }
            
            m_RoundPresenter = new RoundPresenter(m_View.RoundView, m_SpriteLoader);

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

        public void ShowRoundUnits(IReadOnlyList<BattleUnitPresenter> units)
        {
            m_RoundPresenter.ShowUnits(units);
        }
    }
}