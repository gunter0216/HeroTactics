using App.Common.FSM.External;
using App.Core.Startups.External;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;

namespace App.Core.BattleField.External
{
    [Configurator(ContextConstants.CoreContext)]    
    public class BattleConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<BattleController>().AsSingle();
            
            FsmRegistrar.Register<BattleController>(FSMStage.CoreInitStage, CoreStageOrders.BattleField);
        }
    }
}