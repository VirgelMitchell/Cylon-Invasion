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
            SetPlayer();
            Scene scene = SceneManager.GetActiveScene();
            if (scene.buildIndex == 0) { Invoke("LoadMenu", 5f); }
        }

        void Update()
        {
            IncrimentTimers();
            if (NeedReload())
            {
                OnPlayerDeath();
            }
        }

        private void SetPlayer()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        private bool NeedReload()
        {
            if (timeSinceLoad >= loadDelay)
            {
                if (player.GetIsAlive() == false) { Debug.Log("isAlive = false");return true; }
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
            SetPlayer();
        }

        void LoadMenu()     // Called by script ref.
        {
            SceneManager.LoadScene(1);
        }
    }
}