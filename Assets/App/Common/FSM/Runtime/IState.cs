using System.Collections.Generic;

namespace App.Common.FSM.Runtime
{
    public interface IStage
    {
        int GetStage();
        void SyncRun();
        bool IsPredicatesCompleted();
        void SetSystems(List<IInitSystem> systems, List<IPostInitSystem> postInitSystems);
    }
}