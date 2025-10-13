using System;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime.FSM;
using App.Core.Menu.External.View.Panels;
using App.Core.Menu.Runtime;

namespace App.Core.Menu.External.States.Singleplayer
{
    public class CreateGameState : IState, IDisposable
    {
        private readonly GameRecordCreateStrategy m_RecordCreateStrategy;
        private readonly CreateGamePanel m_Panel;
        private readonly StackStateMachine m_StackStateMachine;

        public CreateGameState(StackStateMachine stackStateMachine, CreateGamePanel panel, GameRecordCreateStrategy recordCreateStrategy)
        {
            m_StackStateMachine = stackStateMachine;
            m_Panel = panel;
            m_RecordCreateStrategy = recordCreateStrategy;

            m_Panel.SetActive(false);
            
            m_Panel.SetBackButtonAction(OnBackButtonClick);
            m_Panel.SetCreateButtonAction(OnCreateButtonClick);
        }

        public void Enter()
        {
            m_Panel.SetActive(true);
        }

        public void Exit()
        {
            m_Panel.SetActive(false);
        }

        private void OnBackButtonClick()
        {
            m_StackStateMachine.PopState();
        }

        private void OnCreateButtonClick()
        {
            var name = m_Panel.GetName();
            var status = m_RecordCreateStrategy.Create(name);
            if (status == GameRecordCreateStatus.Successful)
            {
                m_StackStateMachine.PopState();
            }
            else
            {
                // todo
                HLogger.LogError("name is exists");
            }
        }

        public void Dispose()
        {
            
        }
    }
}