using App.Common.DataContainer.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Units.Runtime.Config;
using App.Core.Units.Runtime.Model;

namespace App.Core.Units.Runtime
{
    public interface IUnitsController
    {
        Optional<Unit> CreateUnit(string key);
        void RemoveUnit(Unit unit);
        Optional<Unit> GetUnit(DataReference dataReference);
        Optional<UnitConfig> GetUnitConfig(string key);
    }
}