using System;
using App.Common.Utilities.Utility.Runtime.FSM;
using App.Core.Menu.External.View.Panels;

namespace App.Core.Menu.External.States.Settings
{
    public class SettingsState : IState, IDisposable
    {
        private readonly SettingsPanel m_SettingsPanel;
        private readonly StackStateMachine m_StackStateMachine;

        public SettingsState(StackStateMachine stackStateMachine, SettingsPanel settingsPanel)
        {
            m_SettingsPanel = settingsPanel;
            m_StackStateMachine = stackStateMachine;
            
            m_SettingsPanel.SetActive(false);
            
            m_SettingsPanel.SubscribeToBackButtonClick(OnBackButtonClick);
        }
        
        public void Enter()
        {
            m_SettingsPanel.SetActive(true);
        }

        public void Exit()
        {
            m_SettingsPanel.SetActive(false);
        }
        
        private void OnBackButtonClick()
        {
            m_StackStateMachine.PopState();
        }

        public void Dispose()
        {
            m_SettingsPanel?.UnSubscribeToBackButtonClick(OnBackButtonClick);
        }
    }
}