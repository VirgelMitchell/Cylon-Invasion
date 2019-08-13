using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("in seconds")][SerializeField] float loadDelay = 1.5f;

    private void Awake()
    {
        int sceneLoaders = FindObjectsOfType<SceneLoader>().Length;
        if (sceneLoaders > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0) { Invoke("LoadMenu", 5f); }
    }

    void LoadMenu()     // Called by script ref.
    {
        SceneManager.LoadScene(1);
    }

    void PlayerDead()
    {
        Invoke("LoadMenu", loadDelay);
    }
}