using UnityEngine;

public class CollisionProtocol : MonoBehaviour
{
    [Tooltip("takes a prefab")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        print("Collission detected with " + other.gameObject.name);
    }

    void StartDeathSequence()
    {
        SendMessage("PlayerDead");
        deathFX.SetActive(true);
    }
}