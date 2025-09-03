using App.Common.FSM.External;
using App.Common.FSM.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Game.Canvases.External;
using UnityEngine;
using Zenject;

namespace App.Core.Startups.External
{
    public class MenuSceneStartup : MonoInstaller<MenuSceneStartup>
    {
        [SerializeField] private MainCanvas m_MainCanvas;
        [SerializeField] private PopupCanvas m_PopupCanvas;
        
        public override void InstallBindings()
        {
            Container.BindInstance(m_MainCanvas);
            Container.BindInstance(m_PopupCanvas);

            ConfiguratorsManager.Instance.RunConfigurator(ContextConstants.MenuContext, Container);
            
            var stateMachine = new StateMachine(
                Container.ResolveAll<IInitSystem>(),
                Container.ResolveAll<IPostInitSystem>(),
                FSMRegistrator.GetInfo());
            
            stateMachine.AddState(new DefaultState((int)FSMStage.MenuInitStage));
            stateMachine.SyncRun();
        }
    }
}