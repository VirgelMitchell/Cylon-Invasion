using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnParticleCollision(GameObject other) {
        print("Laser Hit detected on " + gameObject.name + gameObject.transform.parent);
        Destroy(gameObject);
    }
}
