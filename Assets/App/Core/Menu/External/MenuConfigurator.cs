using App.Common.FSM.External;
using App.Core.Startups.External;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;
using App.Menu.UI.External.Data;

namespace App.Menu.UI.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class GlobalMenuConfigurator : Configurator
    {
        public override void Configuration()
        {
            DataRegistrar.Register<GameRecordsData>();
        }
    }
    
    [Configurator(ContextConstants.MenuContext)]    
    public class MenuConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<MenuController>().AsSingle();
            
            FsmRegistrar.Register<MenuController>(FSMStage.MenuInitStage, 0);
        }
    }
}