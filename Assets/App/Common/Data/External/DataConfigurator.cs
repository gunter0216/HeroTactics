using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Data.Runtime;
using App.Common.FSM.External;
using App.Core.Startups.External;
using Zenject;

namespace App.Common.Data.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class DataConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<DataSavePathCreator>().AsSingle();
            container.BindInterfacesAndSelfTo<DataManager>().AsSingle();
            
            FSMRegistrator.Register<DataManager>(FSMStage.StartInitStage, 0);
        }
    }
}