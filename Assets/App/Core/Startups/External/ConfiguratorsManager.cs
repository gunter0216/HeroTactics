using System;
using System.Collections.Generic;
using System.Reflection;
using App.Common.AssemblyManager.Runtime;
using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Logger.Runtime;
using Castle.Core.Internal;
using Zenject;

namespace App.Core.Startups.External
{
    public class ConfiguratorsManager
    {
        private static ConfiguratorsManager m_Instance;

        private readonly Dictionary<int, List<IConfigurator>> m_Configurators = new();

        public static ConfiguratorsManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ConfiguratorsManager();
                }
                
                return m_Instance;
            }
        }

        public void SetConfigurators(IReadOnlyList<AttributeNode> configurators)
        {
            foreach (var configurator in configurators)
            {
                SetConfigurator(configurator);
            }
        }

        private void SetConfigurator(AttributeNode node)
        {
            var attributes = node.Holder.GetAttributes<ConfiguratorAttribute>();
            var instance = Activator.CreateInstance(node.Holder);
            foreach (var attribute in attributes)
            {
                if (instance is IConfigurator configurator)
                {
                    SetConfigurator(attribute.Context, configurator);
                }
                else
                {
                    HLogger.LogError($"Wtf?");
                    return;
                }
            }
        }

        private void SetConfigurator(int context, IConfigurator configurator)
        {
            if (!m_Configurators.TryGetValue(context, out var configurators))
            {
                configurators = new List<IConfigurator>(1);
                m_Configurators.Add(context, configurators);
            }
            
            configurators.Add(configurator);
        }

        public void RunConfigurator(int context, DiContainer container)
        {
            if (!m_Configurators.TryGetValue(context, out var configurators))
            {
                return;
            }

            foreach (var configurator in configurators)
            {
                configurator.Configuration(container);
            }
        }
    }
}