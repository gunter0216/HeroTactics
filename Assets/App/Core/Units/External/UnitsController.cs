using System;
using App.Common.Configs.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.Units.Runtime.Config;

namespace App.Menu.UI.External
{
    public class UnitsController : IInitSystem, IDisposable
    {
        private readonly IConfigLoader m_ConfigLoader;
        
        private UnitsConfigController m_ConfigController;
        
        public UnitsController(IConfigLoader configLoader)
        {
            m_ConfigLoader = configLoader;
        }

        public void Init()
        {
            m_ConfigController = new UnitsConfigController(m_ConfigLoader);
            m_ConfigController.Initialize();
        }

        public void Dispose()
        {
        }
    }
}