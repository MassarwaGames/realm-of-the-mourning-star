using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Loads the MainScene when called.
    /// </summary>
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene"); // Ensure this matches the name of your MainScene
    }
}
