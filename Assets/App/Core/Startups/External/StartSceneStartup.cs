using System.Linq;
using App.Common.AssemblyManager.External;
using App.Common.Autumn.Runtime.Attributes;
using App.Common.Data.Runtime.Attributes;
using App.Common.FSM.External;
using App.Common.FSM.Runtime;
using App.Common.Logger.External;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Startups.External.Phases;
using App.Game.Canvases.External;
using UnityEngine;
using Zenject;

namespace App.Core.Startups.External
{
    public class StartSceneStartup : MonoInstaller<StartSceneStartup>
    {
        [SerializeField] private MainCanvas m_MainCanvas;
        [SerializeField] private PopupCanvas m_PopupCanvas;
        
        public override void InstallBindings()
        {
            Container.BindInstance(m_MainCanvas);
            Container.BindInstance(m_PopupCanvas);

            ConfiguratorsManager.Instance.RunConfigurator(ContextConstants.StartContext, Container);
            
            var stateMachine = new StateMachine(
                Container.ResolveAll<IInitSystem>(),
                Container.ResolveAll<IPostInitSystem>(),
                FSMRegistrator.GetInfo());
            
            stateMachine.AddState(new DefaultState((int)FSMStage.StartInitStage));
            stateMachine.SyncRun();
        }
    }
}