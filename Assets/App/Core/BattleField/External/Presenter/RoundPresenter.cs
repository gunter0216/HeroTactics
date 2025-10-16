using System.Collections.Generic;
using App.Common.Logger.Runtime;
using App.Common.SpriteLoaders.Runtime;
using App.Common.Utilities.Pool.External;
using App.Core.BattleField.External.View.Round;

namespace App.Core.BattleField.External.Presenter
{
    public class RoundPresenter
    {
        private readonly RoundView m_RoundView;
        private readonly ISpriteLoader m_SpriteLoader;
        
        private ComponentPool<RoundUnitView> m_UnitViewPool;
        private List<RoundUnitView> m_ActiveViews;
        
        public RoundPresenter(RoundView roundView, ISpriteLoader spriteLoader)
        {
            m_RoundView = roundView;
            m_SpriteLoader = spriteLoader;
        }

        public void ShowUnits(IReadOnlyList<BattleUnitPresenter> units)
        {
            m_ActiveViews ??= new List<RoundUnitView>(units.Count);
            m_UnitViewPool ??= new ComponentPool<RoundUnitView>(
                    m_RoundView.UnitViewPrefab, 
                    m_RoundView.UnitViewContainer);
            
            m_ActiveViews.ForEach(v => m_UnitViewPool.Release(v));
            m_ActiveViews.Clear();
            for (int i = 0; i < units.Count; i++)
            {
                var unit = units[i];
                var view = m_UnitViewPool.Get();
                if (!view.HasValue)
                {
                    HLogger.LogError("Failed to get RoundUnitView from pool");
                    continue;
                }
                
                var icon = m_SpriteLoader.Load(unit.Unit.Config.IconKey);
                if (!icon.HasValue)
                {
                    HLogger.LogError("Failed to load icon for unit: " + unit.Unit.Config.IconKey);
                    continue;
                }
                
                view.Value.SetIcon(icon.Value);
                if (unit.Unit.Data.PlayerControlled)
                {
                    view.Value.ChangeStateToPlayer();
                }
                else
                {
                    view.Value.ChangeStateToEnemy();
                }

                m_ActiveViews.Add(view.Value);
            }
        }
    }
}