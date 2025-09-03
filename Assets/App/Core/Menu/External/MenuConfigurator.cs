using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Data.Runtime;
using App.Common.FSM.External;
using App.Core.Startups.External;
using App.Menu.UI.External.Data;
using Zenject;

namespace App.Menu.UI.External
{
    [Configurator(ContextConstants.MenuContext)]    
    public class MenuConfigurator : IConfigurator
    {
        public void Configuration(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<MenuController>().AsSingle();
            
            FSMRegistrator.Register<MenuController>(FSMStage.MenuInitStage, 0);
            GlobalDataRegistrator.Register<GameRecordsData>();
        }
    }
}