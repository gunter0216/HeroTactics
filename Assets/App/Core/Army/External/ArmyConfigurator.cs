using App.Common.FSM.External;
using App.Core.Startups.External;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;

namespace App.Menu.UI.External
{
    [Configurator(ContextConstants.CoreContext)]    
    public class ArmyConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<ArmyController>().AsSingle();
            
            FsmRegistrar.Register<ArmyController>(FSMStage.CoreInitStage, 0);
        }
    }
}