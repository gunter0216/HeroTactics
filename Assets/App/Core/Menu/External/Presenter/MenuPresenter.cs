using App.Common.SceneControllers.Runtime;
using App.Common.Utilities.Utility.Runtime.FSM;
using App.Core.Menu.External.States.MainMenu;
using App.Core.Menu.External.States.Multiplayer;
using App.Core.Menu.External.States.Settings;
using App.Core.Menu.External.States.Singleplayer;
using App.Core.Menu.External.View;
using App.Core.Menu.Runtime;
using App.Core.Menu.Runtime.Data;

namespace App.Core.Menu.External.Presenter
{
    public class MenuPresenter
    {
        private readonly MenuViewCreator m_ViewCreator;
        private readonly GameRecordsDataController m_DataController;
        private readonly ISceneManager m_SceneManager;

        private MenuView m_View;
        
        private StackStateMachine m_StackStateMachine;
        private CreateGameState m_CreateGameState;
        private SingleplayerState m_SingleplayerState;
        private MultiplayerState m_MultiplayerState;
        private SettingsState m_SettingsState;
        private MainMenuState m_MainMenuState;

        public MenuPresenter(
            MenuViewCreator viewCreator, 
            GameRecordsDataController dataController,
            ISceneManager sceneManager)
        {
            m_ViewCreator = viewCreator;
            m_DataController = dataController;
            m_SceneManager = sceneManager;
        }

        public bool Initialize()
        {
            if (!CreateView())
            {
                return false;
            }

            m_StackStateMachine = new StackStateMachine();
            var gameRecordCreateStrategy = new GameRecordCreateStrategy(m_DataController);
            var startGameStrategy = new StartGameStrategy(m_SceneManager, m_DataController);
            
            m_CreateGameState = new CreateGameState(m_StackStateMachine, m_View.CreateGamePanel, gameRecordCreateStrategy);
            m_SingleplayerState = new SingleplayerState(
                m_StackStateMachine,
                m_View.SingleplayerPanel,
                m_CreateGameState,
                m_DataController,
                startGameStrategy);
            m_MultiplayerState = new MultiplayerState(m_StackStateMachine, m_View.MultiplayerPanel);
            m_SettingsState = new SettingsState(m_StackStateMachine, m_View.SettingsPanel);
            m_MainMenuState = new MainMenuState(
                m_StackStateMachine,
                m_View.MainMenuPanel,
                m_SingleplayerState,
                m_MultiplayerState,
                m_SettingsState);
            
            m_StackStateMachine.PushState(m_MainMenuState);
            
            var record = m_DataController.GetRecords();
            if (record.Count <= 0)
            {
                gameRecordCreateStrategy.Create("Test");
            }
            
            startGameStrategy.StartGame(record[0].Name);   
            
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
    }
}