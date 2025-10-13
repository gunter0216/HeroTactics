using System;
using App.Common.AssetSystem.Runtime;
using App.Common.Data.Runtime;
using App.Common.Logger.Runtime;
using App.Common.SceneControllers.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Canvases.External;
using App.Core.Menu.External.Presenter;
using App.Core.Menu.Runtime.Data;

namespace App.Core.Menu.External
{
    public class MenuController : IInitSystem, IDisposable
    {
        private readonly MainCanvas m_MainCanvas;
        private readonly IAssetManager m_AssetManager;
        private readonly IDataManager m_DataManager;
        private readonly ISceneManager m_SceneManager;
        
        private MenuPresenter m_Presenter;
        private GameRecordsDataController m_DataController;

        public MenuController(
            MainCanvas mainCanvas, 
            IAssetManager assetManager, 
            IDataManager dataManager, 
            ISceneManager sceneManager)
        {
            m_MainCanvas = mainCanvas;
            m_AssetManager = assetManager;
            m_DataManager = dataManager;
            m_SceneManager = sceneManager;
        }

        public void Init()
        {
            var dataLoader = new GameRecordsDataLoader(m_DataManager);
            m_DataController = new GameRecordsDataController(dataLoader);
            m_DataController.Initialize();
            
            var viewCreator = new MenuViewCreator(m_AssetManager, m_MainCanvas);
            m_Presenter = new MenuPresenter(viewCreator, m_DataController, m_SceneManager);
            if (!m_Presenter.Initialize())
            {
                HLogger.LogError($"Cant initialize");
            }
        }

        public void Dispose()
        {
            /*
            m_CreateGameMenuState?.Dispose();
            m_MultiplayerMenuState?.Dispose();
            m_SettingsMenuState?.Dispose();
            m_SingleplayerMenuState?.Dispose();
            m_MainMenuState?.Dispose();
            */
        }
    }
}