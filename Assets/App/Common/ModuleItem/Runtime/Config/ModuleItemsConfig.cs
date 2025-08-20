﻿using System.Collections.Generic;
using App.Common.ModuleItem.Runtime.Config.Interfaces;

namespace App.Common.ModuleItem.Runtime.Config
{
    public class ModuleItemsConfig : IModuleItemsConfig
    {
        private readonly IReadOnlyList<IModuleItemConfig> m_Configs;

        public IReadOnlyList<IModuleItemConfig> Configs => m_Configs;

        public ModuleItemsConfig(IReadOnlyList<IModuleItemConfig> configs)
        {
            m_Configs = configs;
        }
    }
}