using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkSpawnManager : MonoBehaviour
{
  public struct ClientApprovalInformation
  {
    public NetworkManager.ConnectionApprovalRequest Request;
    public NetworkManager.ConnectionApprovalResponse Response;
  }

  public NetworkObject CharacterPrefab;
  Queue<ClientApprovalInformation> ClientQueue = new Queue<ClientApprovalInformation>();

  public void Setup()
  {
    NetworkManager.Singleton.ConnectionApprovalCallback += ConnectionApproval;
  }

  private void ConnectionApproval(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
  {
    response.Approved = true;
    if (ClientQueue.Count <= 0)
    {
      response.CreatePlayerObject = true;
      SpawnClient(new ClientApprovalInformation()
      {
        Request = request,
        Response = response
      });
    }
    else
    {
      ClientQueue.Enqueue(new ClientApprovalInformation()
      {
        Request = request,
        Response = response
      });
    }
  }

  private void SpawnClient(ClientApprovalInformation clientApprovalInformation)
  {
    clientApprovalInformation.Response.Pending = false;
    StartCoroutine(SpawnPlayerPrefab(clientApprovalInformation.Request.ClientNetworkId));
  }

  private IEnumerator SpawnPlayerPrefab(ulong clientNetworkId)
  {
    var networkObject = NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(clientNetworkId);
    while (networkObject == null)
    {
      yield return new WaitForEndOfFrame();
      networkObject = NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(clientNetworkId);
    }

    var playerCharacter = Instantiate(CharacterPrefab);
    playerCharacter.Spawn(true);

    if (ClientQueue.Count > 0)
    {
      var client = ClientQueue.Dequeue();
      SpawnClient(client);
    }
  }
}