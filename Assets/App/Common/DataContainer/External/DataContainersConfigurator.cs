using App.Common.Configs.Runtime;
using App.Common.DataContainer.Runtime;
using App.Common.DataContainer.Runtime.Data.Loader;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;

namespace App.Common.Configs.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class DataContainersConfigurator : Core.Startups.External.Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<ContainerDataLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContainersDataManager>().AsSingle();
        }
    }
}