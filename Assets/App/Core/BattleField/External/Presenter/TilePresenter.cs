using App.Core.Field.External.View;

namespace App.Menu.UI.External
{
    public class TilePresenter
    {
        private readonly int m_X;
        private readonly int m_Y;
        private readonly TileView m_View;

        public int X => m_X;
        public int Y => m_Y;
        public TileView View => m_View;

        public TilePresenter(TileView view, int x, int y)
        {
            m_X = x;
            m_Y = y;
            m_View = view;
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