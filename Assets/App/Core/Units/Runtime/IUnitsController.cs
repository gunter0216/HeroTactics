using App.Common.DataContainer.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Menu.UI.External.Model;

namespace App.Menu.UI.External
{
    public interface IUnitsController
    {
        Optional<Unit> CreateUnit(string key);
        void RemoveUnit(Unit unit);
        Optional<Unit> GetUnit(DataReference dataReference);
    }
}