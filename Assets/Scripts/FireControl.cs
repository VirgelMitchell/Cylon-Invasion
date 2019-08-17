using UnityEngine;

namespace Control
{
    public class FireControl : MonoBehaviour
    {
        [SerializeField] ParticleSystem[] cannons;
        [SerializeField] int damage = 1;

        bool isDead = false;

        private void Start()
        {
            ValidateCannons();
        }

         private void Update()
        {
            if (isDead) { return; }
            CheckRightTrigger();
            CheckLeftTrigger();
            
        }

        public int GetDamage() { return damage; }

        private void CheckLeftTrigger()
        {
            if (Input.GetAxis("Fire1") <= -Mathf.Epsilon)
            {

            }
        }

        private void CheckRightTrigger()
        {
            if (Input.GetAxis("Fire1") >= 0.1)
            {
                foreach (ParticleSystem system in cannons)
                {
                    if (isCannon(system))
                    {
                        var emission = system.emission;
                        emission.enabled = true;
                    }
                }
            }
            else
            {
                foreach (ParticleSystem system in cannons)
                {
                    if (isCannon(system))
                    {
                        var emission = system.emission;
                        emission.enabled = false;
                    }
                }
            }
        }

        // This Method depends on Names of Game Objects
        bool isCannon(ParticleSystem system)
        {
            if (
                system.name == "Starboard Laser Cannon" &&
                system.transform.parent.name == "Player Ship")
            { return true; }
            
            else if (
                system.name == "Port Laser Cannon" &&
                system.transform.parent.name == "Player Ship")
            { return true; }
            
            else { return false; }
        }

        private void ValidateCannons()
        {
            if (cannons == null)
            {
                Debug.LogWarning("Cannons Invalid");
                cannons = GameObject.FindObjectsOfType<ParticleSystem>();
            }
        }

        void OnDeath(string tag)    //Called by String Ref
        {
            if (gameObject.tag == tag)
            {
                isDead = true;
            }
        }
    }
}