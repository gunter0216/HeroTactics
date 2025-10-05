using App.Core.Player.External;
using Unity.Netcode;
using UnityEngine;

namespace App.Core.Network.External
{
    public class CoreNetworkManager : MonoBehaviour
    {
        private NetworkManager m_NetworkManager;

        void Awake()
        {
            m_NetworkManager = GetComponent<NetworkManager>();

            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
        }

        private void ApprovalCheck(
            NetworkManager.ConnectionApprovalRequest request, 
            NetworkManager.ConnectionApprovalResponse response)
        {
            NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.UTF8.GetBytes("room password");
            
            var clientId = request.ClientNetworkId;

            // Additional connection data defined by user code
            var connectionData = request.Payload;

            // Your approval logic determines the following values
            response.Approved = true;
            response.CreatePlayerObject = true;

            // The Prefab hash value of the NetworkPrefab, if null the default NetworkManager player Prefab is used
            response.PlayerPrefabHash = null;

            // Position to spawn the player object (if null it uses default of Vector3.zero)
            response.Position = Vector3.zero;

            // Rotation to spawn the player object (if null it uses the default of Quaternion.identity)
            response.Rotation = Quaternion.identity;

            // If response.Approved is false, you can provide a message that explains the reason why via ConnectionApprovalResponse.Reason
            // On the client-side, NetworkManager.DisconnectReason will be populated with this message via DisconnectReasonMessage
            response.Reason = "Some reason for not approving the client";

            // If additional approval steps are needed, set this to true until the additional steps are complete
            // once it transitions from true to false the connection approval response will be processed.
            response.Pending = false;
        }

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 700, 700));
            if (!m_NetworkManager.IsClient && !m_NetworkManager.IsServer)
            {
                StartButtons();
            }
            else
            {
                StatusLabels();

                SubmitNewPosition();
            }

            GUILayout.EndArea();
        }

        void StartButtons()
        {
            if (GUILayout.Button("Host")) m_NetworkManager.StartHost();
            if (GUILayout.Button("Client")) m_NetworkManager.StartClient();
            if (GUILayout.Button("Server")) m_NetworkManager.StartServer();
        }

         void StatusLabels()
        {
            var mode = m_NetworkManager.IsHost ?
                "Host" : m_NetworkManager.IsServer ? "Server" : "Client";

            GUILayout.Label("Transport: " +
                            m_NetworkManager.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
        }

         void SubmitNewPosition()
        {
            if (GUILayout.Button(m_NetworkManager.IsServer ? "Move" : "Request Position Change"))
            {
                if (m_NetworkManager.IsServer && !m_NetworkManager.IsClient )
                {
                    foreach (ulong uid in m_NetworkManager.ConnectedClientsIds)
                    {
                        m_NetworkManager.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<CorePlayer>().Move();
                    }
                }
                else
                {
                    var playerObject = m_NetworkManager.SpawnManager.GetLocalPlayerObject();
                    var player = playerObject.GetComponent<CorePlayer>();
                    player.Move();
                }
            }
        }
    }
}