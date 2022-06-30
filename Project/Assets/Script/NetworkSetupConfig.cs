using UnityEngine.SceneManagement;
using UnityEngine;

public class NetworkSetupConfig : MonoBehaviour
{
  public enum Network
  {
    Server,
    Client
  }

  public Network Setup;

  void Start()
  {
    switch (Setup)
    {
      case Network.Server:
        SceneManager.LoadScene("ServerScene");
        return;
      case Network.Client:
        SceneManager.LoadScene("ClientScene");
        return;
    }
  }
}
