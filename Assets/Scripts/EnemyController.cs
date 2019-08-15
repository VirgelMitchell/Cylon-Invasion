using UnityEngine;
using Core;

namespace Control
{
    public class EnemyController : MonoBehaviour
    {
        [Tooltip("int")] [SerializeField] int pointValue = 10;
        [Tooltip("takes prefab")] [SerializeField] GameObject deathFX;
        [SerializeField] Transform parent;

        ScoreBoard scoreBoard;

        private void Start()
        {
            SetParent();
            AddCollider();
            scoreBoard = FindObjectOfType<Canvas>().GetComponent<ScoreBoard>();
        }

        private void SetParent()
        {
            if (parent = null)
            {
                parent = GameObject.Find("Spawned at Runtime").transform;
                if (parent = null)
                {
                    parent = new GameObject("Spawned at Runtime").transform;
                }
            }
        }

        void AddCollider()
        {
            Collider collider = gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = false;
        }

        void OnParticleCollision(GameObject other)
        {
            SpawnDeathEffects();
            scoreBoard.AddToScore(pointValue);
            Destroy(gameObject);
        }

        private void SpawnDeathEffects()
        {
            GameObject fx =
                Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            fx.AddComponent<Core.Cleaner>();
        }
    }
}