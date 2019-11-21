using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderDetectorScript : MonoBehaviour
{
    public static bool loaded = false;

    // called zero
    private void Awake()
    {
    }

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        loaded = true;
    }

    // called third
    void Start()
    {
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
