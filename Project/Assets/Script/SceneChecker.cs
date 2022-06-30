using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
