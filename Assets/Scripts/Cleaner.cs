using UnityEngine;

namespace Core
{
   public class Cleaner : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
} 
}