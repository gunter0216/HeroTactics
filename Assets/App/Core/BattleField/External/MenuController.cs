using System;
using App.Battle.UI.External.Presenter;
using App.Common.AssetSystem.Runtime;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Game.Canvases.External;
using App.Menu.UI.External.Data;
using App.Menu.UI.External.Fabric;
using App.Menu.UI.External.Presenter;
using App.Menu.UI.Runtime.Data;

namespace App.Menu.UI.External
{
    public class BattleController : IInitSystem, IDisposable
    {
        private readonly MainCanvas m_MainCanvas;
        private readonly IAssetManager m_AssetManager;

        private BattleViewPresenter m_Presenter;
        
        public BattleController(
            MainCanvas mainCanvas, 
            IAssetManager assetManager)
        {
            m_MainCanvas = mainCanvas;
            m_AssetManager = assetManager;
        }

        public void Init()
        {
            m_Presenter = new BattleViewPresenter(new BattleViewCreator(m_AssetManager, m_MainCanvas));
            m_Presenter.Initialize();
        }

        public void Dispose()
        {
        }
    }
}