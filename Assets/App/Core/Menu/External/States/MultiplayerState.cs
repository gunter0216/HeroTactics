using System;
using App.Game.Utility.Runtime.MenuSM;
using App.Menu.UI.Runtime.View.Panels;

namespace App.Menu.UI.Runtime.States
{
    public class MultiplayerState : IState, IDisposable
    {
        private readonly MultiplayerPanel m_MultiplayerPanel;
        private readonly StackStateMachine m_StackStateMachine;

        public MultiplayerState(StackStateMachine stackStateMachine, MultiplayerPanel multiplayerPanel)
        {
            m_MultiplayerPanel = multiplayerPanel;
            m_StackStateMachine = stackStateMachine;
            
            m_MultiplayerPanel.SetActive(false);
            
            m_MultiplayerPanel.SubscribeToBackButtonClick(OnBackButtonClick);
        }

        public void Enter()
        {
            m_MultiplayerPanel.SetActive(true);
        }

        public void Exit()
        {
            m_MultiplayerPanel.SetActive(false);
        }

        private void OnBackButtonClick()
        {
            m_StackStateMachine.PopState();
        }

        public void Dispose()
        {
            m_MultiplayerPanel?.UnSubscribeToBackButtonClick(OnBackButtonClick);
        }
    }
}