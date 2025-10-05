using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace App.Menu.UI.Runtime.View.Panels
{
    public class MultiplayerPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField m_UserNameInputField;
        [SerializeField] private Button m_HostButton;
        [SerializeField] private Button m_ConnectButton;
        [SerializeField] private Button m_BackButton;

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }
        
        public string GetUserName()
        {
            return m_UserNameInputField.text;
        }
        
        public void SetHostButtonClickCallback(UnityAction action)
        {
            m_HostButton.onClick.RemoveAllListeners();
            m_HostButton.onClick.AddListener(action);
        }
        
        public void SetConnectButtonClickCallback(UnityAction action)
        {
            m_ConnectButton.onClick.RemoveAllListeners();
            m_ConnectButton.onClick.AddListener(action);
        }
        
        public void SetBackButtonClickCallback(UnityAction action)
        {
            m_BackButton.onClick.RemoveAllListeners();
            m_BackButton.onClick.AddListener(action);
        }
    }
}