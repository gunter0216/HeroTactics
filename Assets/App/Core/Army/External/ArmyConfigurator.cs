using App.Common.FSM.External;
using App.Core.Army.Runtime.Data;
using App.Core.Startups.External;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;

namespace App.Menu.UI.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class GlobalArmyConfigurator : Configurator
    {
        public override void Configuration()
        {
            DataRegistrar.Register<ArmyData>();
        }
    }
    
    [Configurator(ContextConstants.CoreContext)]    
    public class ArmyConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<ArmyController>().AsSingle();
            
            FsmRegistrar.Register<ArmyController>(FSMStage.CoreInitStage, CoreStageOrders.Army);
        }
    }
}