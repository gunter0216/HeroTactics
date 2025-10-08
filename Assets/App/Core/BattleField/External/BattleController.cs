using System;
using App.Battle.UI.External.Presenter;
using App.Common.AssetSystem.Runtime;
using App.Common.Configs.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Services;
using App.Game.Canvases.External;
using App.Menu.UI.External.Fabric;

namespace App.Menu.UI.External
{
    public class BattleController : IInitSystem, IDisposable
    {
        private readonly MainCanvas m_MainCanvas;
        private readonly IAssetManager m_AssetManager;
        private readonly IArmyController m_ArmyController;
        private readonly IConfigLoader m_ConfigLoader;

        private BattleViewPresenter m_Presenter;
        private BattleUnitsService m_BattleUnitsService;
        private BattlePlayer m_BattlePlayer;
        private BattleConfigController m_ConfigController;

        public BattleController(
            MainCanvas mainCanvas, 
            IAssetManager assetManager, 
            IArmyController armyController, 
            IConfigLoader configLoader)
        {
            m_MainCanvas = mainCanvas;
            m_AssetManager = assetManager;
            m_ArmyController = armyController;
            m_ConfigLoader = configLoader;
        }

        public void Init()
        {
            m_ConfigController = new BattleConfigController(m_ConfigLoader);
            m_ConfigController.Initialize();
            
            m_Presenter = new BattleViewPresenter(new BattleViewCreator(m_AssetManager, m_MainCanvas));
            m_Presenter.Initialize();

            m_BattleUnitsService = new BattleUnitsService(m_ArmyController);

            m_BattlePlayer = new BattlePlayer(m_BattleUnitsService, m_Presenter, m_AssetManager, m_ConfigController);
            m_BattlePlayer.Initialize();
            m_BattlePlayer.StartBattle();
        }

        public void Dispose()
        {
        }
    }
}