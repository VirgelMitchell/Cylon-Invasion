using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        [Tooltip("in seconds")] [SerializeField] float loadDelay = 1.5f;
        Health player;
        float timeSinceLoad = Mathf.Infinity;

        private void Awake()
        {
            int sceneLoaders = FindObjectsOfType<SceneLoader>().Length;
            if (sceneLoaders > 1) { Destroy(gameObject); }
            else { DontDestroyOnLoad(gameObject); }
        }

        void Start()
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.buildIndex == 0) { Invoke("LoadMenu", loadDelay); }
            else { ResetPlayer(); }
        }

        void Update()
        {
            if (player == null) { ResetPlayer(); }
            IncrimentTimers();
            if (NeedReload())
            {
                OnPlayerDeath();
            }
        }

        private void ResetPlayer()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        private bool NeedReload()
        {
            if (player == null) { ResetPlayer(); }
            if (timeSinceLoad >= loadDelay)
            {
                if (player.GetIsAlive() == false) { return true; }
            }
            return false;
        }

        private void IncrimentTimers()
        {
            timeSinceLoad += Time.deltaTime;
        }

        void OnPlayerDeath()
        {
            timeSinceLoad = 0f;
            LoadMenu();
        }

        void LoadMenu()     // Called by script ref.
        {
            SceneManager.LoadScene(1);
        }
    }
}