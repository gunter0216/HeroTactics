using System;
using App.Common.AssetSystem.Runtime;
using App.Common.Autumn.Runtime.Attributes;
using App.Common.Data.Runtime;
using App.Common.FSM.Runtime;
using App.Common.FSM.Runtime.Attributes;
using App.Common.Logger.Runtime;
using App.Common.SceneControllers.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Startups.External.Phases;
using App.Game;
using App.Game.Canvases;
using App.Game.Canvases.External;
using App.Game.Utility.Runtime.MenuSM;
using App.Menu.UI.External.Data;
using App.Menu.UI.Runtime;
using App.Menu.UI.Runtime.Data;
using App.Menu.UI.Runtime.States;
using App.Menu.UI.Runtime.View;

namespace App.Menu.UI.External
{
    [Stage(typeof(MenuInitPhase), 0)]
    public class MenuSceneMenuController : IInitSystem, IDisposable
    {
        private const string m_MenuSceneMenuAssetKey = "MenuSceneMenuView";
        private readonly StringKeyEvaluator m_MenuSceneMenuAssetKeyEvaluator = new(m_MenuSceneMenuAssetKey);
        
        private readonly MainCanvas m_MainCanvas;
        private readonly IAssetManager m_AssetManager;
        private readonly IDataManager m_DataManager;
        private readonly ISceneManager m_SceneManager;

        private CreateGameMenuState m_CreateGameMenuState;
        // private MainMenuState m_MainMenuState;
        private MultiplayerMenuState m_MultiplayerMenuState;
        // private SettingsMenuState m_SettingsMenuState;
        private SingleplayerMenuState m_SingleplayerMenuState;
        
        private MenuMachine m_MenuMachine;

        private GameRecordsDataController m_DataController;
        private MenuSceneMenuView m_View;

        public MenuSceneMenuController(
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
            /*
            var view = m_AssetManager.InstantiateSync<MenuSceneMenuView>(
                m_MenuSceneMenuAssetKeyEvaluator,
                m_MainCanvas.GetContent());
            if (!view.HasValue)
            {
                HLogger.LogError("cant create MenuSceneMenuView");
                return;
            }

            var dataLoader = new GameRecordsDataLoader(m_DataManager);
            m_DataController = new GameRecordsDataController(dataLoader);

            m_View = view.Value;

            m_MenuMachine = new MenuMachine();
            var gameRecordCreateStrategy = new GameRecordCreateStrategy(m_DataController);
            var startGameStrategy = new StartGameStrategy(m_SceneManager, m_DataController);
            
            m_CreateGameMenuState = new CreateGameMenuState(m_MenuMachine, m_View.CreateGamePanel, gameRecordCreateStrategy);
            m_SingleplayerMenuState = new SingleplayerMenuState(
                m_MenuMachine, 
                m_View.SingleplayerPanel,
                m_CreateGameMenuState,
                m_DataController,
                startGameStrategy);
            m_MultiplayerMenuState = new MultiplayerMenuState(m_MenuMachine, m_View.MultiplayerPanel);
            m_SettingsMenuState = new SettingsMenuState(m_MenuMachine, m_View.SettingsPanel);
            m_MainMenuState = new MainMenuState(
                m_MenuMachine, 
                m_View.MainMenuPanel, 
                m_SingleplayerMenuState, 
                m_MultiplayerMenuState, 
                m_SettingsMenuState);
            
            m_MenuMachine.PushState(m_MainMenuState);
            */
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