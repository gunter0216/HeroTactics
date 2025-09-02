using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Logger.Runtime;
using App.Core.Startups.External;
using Zenject;

namespace App.Common.Logger.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class LoggerConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.Bind<ILogger>().To<Runtime.Logger>().AsSingle();
        }
    }
}