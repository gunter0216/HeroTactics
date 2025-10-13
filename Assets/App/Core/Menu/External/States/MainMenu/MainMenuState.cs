using System;
using App.Common.Utilities.Utility.Runtime.FSM;
using App.Core.Menu.External.States.Multiplayer;
using App.Core.Menu.External.States.Settings;
using App.Core.Menu.External.States.Singleplayer;
using App.Core.Menu.External.View.Panels;
using UnityEngine;

namespace App.Core.Menu.External.States.MainMenu
{
    public class MainMenuState : IState, IDisposable
    {
        private readonly SingleplayerState m_SingleplayerState;
        private readonly MultiplayerState m_MultiplayerState;
        private readonly SettingsState m_SettingsState;
        private readonly MainMenuPanel m_MainMenuPanel;
        private readonly StackStateMachine m_StackStateMachine;

        public MainMenuState(StackStateMachine stackStateMachine, MainMenuPanel mainMenuPanel, SingleplayerState singleplayerState, MultiplayerState multiplayerState, SettingsState settingsState)
        {
            m_MainMenuPanel = mainMenuPanel;
            m_SingleplayerState = singleplayerState;
            m_MultiplayerState = multiplayerState;
            m_SettingsState = settingsState;
            m_StackStateMachine = stackStateMachine;
            
            m_MainMenuPanel.SetActive(false);
            
            m_MainMenuPanel.SubscribeToSingleplayerButtonClick(OnSingleplayerButtonClick);
            m_MainMenuPanel.SubscribeToMultiplayerButtonClick(OnMultiplayerButtonClick);
            m_MainMenuPanel.SubscribeToSettingsButtonClick(OnSettingsButtonClick);
            m_MainMenuPanel.SubscribeToExitButtonClick(OnExitButtonClick);
        }

        public void Enter()
        {
            m_MainMenuPanel.SetActive(true);
        }

        public void Exit()
        {
            m_MainMenuPanel.SetActive(false);
        }
        
        private void OnExitButtonClick()
        {
            Application.Quit();
        }

        private void OnSettingsButtonClick()
        {
            m_StackStateMachine.PushState(m_SettingsState);
        }

        private void OnMultiplayerButtonClick()
        {
            m_StackStateMachine.PushState(m_MultiplayerState);
        }

        private void OnSingleplayerButtonClick()
        {
            m_StackStateMachine.PushState(m_SingleplayerState);
        }

        public void Dispose()
        {
            if (m_MainMenuPanel != null)
            {
                m_MainMenuPanel.UnSubscribeToSingleplayerButtonClick(OnSingleplayerButtonClick);
                m_MainMenuPanel.UnSubscribeToMultiplayerButtonClick(OnMultiplayerButtonClick);
                m_MainMenuPanel.UnSubscribeToSettingsButtonClick(OnSettingsButtonClick);
                m_MainMenuPanel.UnSubscribeToExitButtonClick(OnExitButtonClick);
            }
        }
    }
}