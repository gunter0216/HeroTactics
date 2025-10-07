using System.Collections.Generic;
using App.Core.Army.Runtime;

namespace App.Menu.UI.External
{
    public interface IArmyController
    {
        IReadOnlyList<ArmyUnit> GetArmyUnits();
    }
}