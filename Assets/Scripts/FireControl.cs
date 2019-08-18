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
            if (isDead)
            {
                ToggleCannons(false);
                return;
            }
            ToggleCannons(CheckRightTrigger());
        }

        public int GetDamage() { return damage; }

        private void CheckLeftTrigger()
        {
            if (Input.GetAxis("Fire1") <= -Mathf.Epsilon)
            {

            }
        }

        private bool CheckRightTrigger()
        {
            if (Input.GetAxis("Fire1") >= 0.1)  { return true; }
            else                                { return false; }
        }

        private void ToggleCannons(bool active)
        {
            foreach (ParticleSystem system in cannons)
            {
                if (isCannon(system))
                {
                    var emission = system.emission;
                    emission.enabled = active;
                }
            }
        }

        // This Method depends on Names of Game Objects
        bool isCannon(ParticleSystem system)
        {
            if ( system.name == "Starboard Laser Cannon" ||
                 system.name == "Port Laser Cannon" )
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

        void OnDeath()    //Called by String Ref
        {
            isDead = true;
        }
    }
}