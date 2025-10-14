using System;
using App.Common.AssetSystem.Runtime;
using App.Common.Configs.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Army.Runtime;
using App.Core.BattleField.External.Battle;
using App.Core.BattleField.External.Fabric;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Services;
using App.Core.Canvases.External;

namespace App.Core.BattleField.External
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
            m_BattlePlayer.StartBattle("battle_001");
        }

        public void Dispose()
        {
        }
    }
}