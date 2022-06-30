using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine;
using System;

public class StartServerScr : MonoBehaviour
{
  public NetworkSpawnManager SpawnManager;

  void Start()
  {
    SpawnManager.Setup();
    NetworkManager.Singleton.StartServer();
    SceneManager.LoadScene("WorldScene");
  }
}
