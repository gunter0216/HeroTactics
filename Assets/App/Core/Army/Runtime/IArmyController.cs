using System.Collections.Generic;
using App.Core.Army.Runtime.Units;

namespace App.Core.Army.Runtime
{
    public interface IArmyController
    {
        IReadOnlyList<ArmyUnit> GetArmyUnits();
    }
}