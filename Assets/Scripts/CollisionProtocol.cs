using System.Collections;
using UnityEngine;

namespace Core
{
    public class CollisionProtocol : MonoBehaviour
    {
        [Tooltip("Prefab")] [SerializeField] GameObject deathFX;

        private void OnTriggerEnter(Collider other)
        {
            StartDeathSequence();
        }

        void StartDeathSequence()
        {
            SendMessage("OnDeath");
            deathFX.SetActive(true);
        }
    }
}