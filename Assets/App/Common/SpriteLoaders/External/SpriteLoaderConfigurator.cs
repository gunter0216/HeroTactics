using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.FSM.External;
using App.Core.Startups.External;
using Zenject;

namespace App.Game.SpriteLoaders.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class SpriteLoaderConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<SpriteLoader>().AsSingle();
            
            FSMRegistrator.Register<SpriteLoader>(FSMStage.StartInitStage, 0);
        }
    }
}