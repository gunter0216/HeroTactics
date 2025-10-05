using App.Common.AssetSystem.Runtime;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.External.View;
using App.Game.Canvases.External;

namespace App.Menu.UI.External.Fabric
{
    public class BattleViewCreator
    {
        private const string m_AssetKey = "BattleView";
        
        private readonly IAssetManager m_AssetManager;
        private readonly MainCanvas m_MainCanvas;

        public BattleViewCreator(IAssetManager assetManager, MainCanvas mainCanvas)
        {
            m_AssetManager = assetManager;
            m_MainCanvas = mainCanvas;
        }

        public Optional<BattleView> Create()
        {
            var view = m_AssetManager.InstantiateSync<BattleView>(
                new StringKeyEvaluator(m_AssetKey),
                m_MainCanvas.GetContent());
            if (!view.HasValue)
            {
                HLogger.LogError("cant create BattleView");
                return Optional<BattleView>.Fail();
            }
            
            return view;
        }
    }
}