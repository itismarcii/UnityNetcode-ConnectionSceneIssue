using Unity.Netcode;
using UnityEngine;

public class ClientConnector : MonoBehaviour
{
  void Update()
  {
    if (NetworkManager.Singleton.IsClient) return;
    byte[] ConnectionData = new byte[0];
    NetworkManager.Singleton.NetworkConfig.ConnectionData = ConnectionData;
    NetworkManager.Singleton.StartClient();
  }
}
