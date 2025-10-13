using System;
using App.Core.BattleField.External.View.Field;

namespace App.Core.BattleField.External.Presenter
{
    public class TilePresenter
    {
        private readonly int m_X;
        private readonly int m_Y;
        private readonly TileView m_View;
        
        private event Action<TilePresenter> m_OnClickCallback;

        public int X => m_X;
        public int Y => m_Y;
        public TileView View => m_View;

        public TilePresenter(
            TileView view, 
            int x, 
            int y,
            Action<TilePresenter> onClickCallback)
        {
            m_X = x;
            m_Y = y;
            m_OnClickCallback = onClickCallback;
            m_View = view;
        }

        public void Initialize()
        {
            m_View.SetClickCallback(OnClick);
        }

        private void OnClick()
        {
            m_OnClickCallback?.Invoke(this);
        }

        public void StayLight()
        {
            m_View.StayLight();
        }
        
        public void StayDefault()
        {
            m_View.StayDefault();
        }
    }
}