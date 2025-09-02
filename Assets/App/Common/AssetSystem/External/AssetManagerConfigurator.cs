using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Core.Startups.External;
using Zenject;

namespace App.Common.AssetSystem.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class AssetManagerConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<AssetManager>().AsSingle();
        }
    }
}