using App.Common.SceneControllers.Runtime;
using App.Common.Timer.Runtime;
using App.Core.Menu.Runtime.Data;

namespace App.Core.Menu.Runtime
{
    public class StartGameStrategy : IStartGameStrategy
    {
        private readonly ISceneManager m_SceneManager;
        private readonly GameRecordsDataController m_DataController;

        public StartGameStrategy(ISceneManager sceneManager, GameRecordsDataController dataController)
        {
            m_SceneManager = sceneManager;
            m_DataController = dataController;
        }

        public void StartGame(string name)
        {
            m_DataController.SetLastLogin(name, TimeHelper.Now.Ticks);
            m_SceneManager.LoadScene(SceneConstants.CoreScene);
        }
    }
}