using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.FSM.External;
using App.Core.Startups.External;
using Zenject;

namespace App.Core.StartScene.External
{
    [Configurator(ContextConstants.StartContext)]    
    public class StartSceneConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<StartSceneController>().AsSingle();
            
            FSMRegistrator.Register<StartSceneController>(FSMStage.StartInitStage, 100_100);
        }
    }
}