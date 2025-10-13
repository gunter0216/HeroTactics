using System;
using App.Common.Utilities.Utility.Runtime.FSM;
using App.Core.Menu.External.View.Panels.Multiplayer;

namespace App.Core.Menu.External.States.Multiplayer
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

            m_MultiplayerPanel.SetHostButtonClickCallback(OnHostButtonClick);
            m_MultiplayerPanel.SetConnectButtonClickCallback(OnConnectButtonClick);
            m_MultiplayerPanel.SetBackButtonClickCallback(OnBackButtonClick);
        }

        public void Enter()
        {
            m_MultiplayerPanel.SetActive(true);
        }

        public void Exit()
        {
            m_MultiplayerPanel.SetActive(false);
        }

        private void OnHostButtonClick()
        {
            if (!IsUserNameValid())
            {
                return;
            }
            
            // todo
        }

        private void OnConnectButtonClick()
        {
            if (!IsUserNameValid())
            {
                return;
            }
            
            // todo
        }

        private void OnBackButtonClick()
        {
            m_StackStateMachine.PopState();
        }
        
        private bool IsUserNameValid()
        {
            var userName = m_MultiplayerPanel.GetUserName();
            return !string.IsNullOrEmpty(userName) && userName.Length >= 3;
        }

        public void Dispose()
        {
        }
    }
}