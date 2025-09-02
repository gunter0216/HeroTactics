using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Core.Startups.External;
using Zenject;

namespace App.Common.SceneControllers.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class SceneManagerConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<SceneManager>().AsSingle();
        }
    }
}