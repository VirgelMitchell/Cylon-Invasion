using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("LoadMenu", 5f);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
