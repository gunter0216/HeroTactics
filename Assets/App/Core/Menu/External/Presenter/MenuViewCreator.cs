using App.Common.AssetSystem.Runtime;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Canvases.External;
using App.Core.Menu.External.View;

namespace App.Core.Menu.External.Presenter
{
    public class MenuViewCreator
    {
        private const string m_MenuAssetKey = "MenuView";
        
        private readonly IAssetManager m_AssetManager;
        private readonly MainCanvas m_MainCanvas;

        public MenuViewCreator(IAssetManager assetManager, MainCanvas mainCanvas)
        {
            m_AssetManager = assetManager;
            m_MainCanvas = mainCanvas;
        }

        public Optional<MenuView> Create()
        {
            var view = m_AssetManager.InstantiateSync<MenuView>(
                new StringKeyEvaluator(m_MenuAssetKey),
                m_MainCanvas.GetContent());
            if (!view.HasValue)
            {
                HLogger.LogError("cant create MenuSceneMenuView");
                return Optional<MenuView>.Fail();
            }
            
            return view;
        }
    }
}