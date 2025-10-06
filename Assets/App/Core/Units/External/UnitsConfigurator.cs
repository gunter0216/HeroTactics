using App.Common.FSM.External;
using App.Core.Startups.External;
using App.Core.Startups.External.Attributes;
using App.Core.Startups.External.Constants;
using App.Menu.UI.External.Data;

namespace App.Menu.UI.External
{
    [Configurator(ContextConstants.CoreContext)]    
    public class UnitsConfigurator : Configurator
    {
        public override void Configuration()
        {
            Container.BindInterfacesAndSelfTo<UnitsController>().AsSingle();
            
            FsmRegistrar.Register<UnitsController>(FSMStage.CoreInitStage, 0);
        }
    }
}