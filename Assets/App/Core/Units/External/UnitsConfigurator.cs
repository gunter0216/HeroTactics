using App.Common.FSM.External;
using App.Core.Startups.External;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;
using App.Core.Units.Runtime.Data;

namespace App.Core.Units.External
{
    [Configurator(ContextConstants.GlobalContext)]    
    public class GlobalUnitsConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<UnitsContainerData>().AsSingle();
            DataRegistrar.Register<UnitsContainerData>();
        }
    }
    
    [Configurator(ContextConstants.CoreContext)]    
    public class UnitsConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<UnitsController>().AsSingle();
            
            FsmRegistrar.Register<UnitsController>(FSMStage.CoreInitStage, CoreStageOrders.Units);
        }
    }
}