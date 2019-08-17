using UnityEngine;
using CPIM = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager;

namespace Control
{
    public class MovementControl : MonoBehaviour
    {
        [Header("Movement")]
        [Tooltip("in m")] [SerializeField] float horizontalRange = 10f;
        [Tooltip("in m")] [SerializeField] float verticalRange = 5.5f;
        [Tooltip("in m/s^2")] [SerializeField] float speed = 25f;

        [Header("Position Modifiers")]
        [SerializeField] float pitchFactor = -0.8f;
        [SerializeField] float yawFactor = 1.4f;
        [SerializeField] float rollFactor = 5f;

        bool isDead = false;
        Vector2 sThrow = new Vector2();
        Vector3 displacement = new Vector3();

        void Update()
        {
            if (isDead) { return; }
            GetInput();
            TranslateShip();
            RotateShip();
        }

        private void GetInput()
        {
            sThrow.x = CPIM.GetAxis("Horizontal");
            displacement.x = sThrow.x * speed * Time.deltaTime;

            sThrow.y = CPIM.GetAxis("Vertical");
            displacement.y = sThrow.y * speed * Time.deltaTime;
        }

        void TranslateShip()
        {
            Vector3 currentPosition = transform.localPosition;
            Vector3 newPosition = currentPosition + displacement;
            float newX, newY;
            newX = Mathf.Clamp(newPosition.x, -horizontalRange, horizontalRange);
            newY = Mathf.Clamp(newPosition.y, -verticalRange, verticalRange);
            Vector3 clampedNewPos = new Vector3(newX, newY, newPosition.z);

            transform.localPosition = clampedNewPos;
        }

        void RotateShip()
        {
            float pitch = (transform.localPosition.y + sThrow.y) * pitchFactor;
            float yaw = transform.localPosition.x * yawFactor;
            float roll = sThrow.x * rollFactor;

            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
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