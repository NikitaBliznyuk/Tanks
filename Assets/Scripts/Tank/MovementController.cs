using UnityEngine;

namespace Tank.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private float moveSpeed = 10.0f;

        [SerializeField]
        private float rotationSpeed = 125.0f;
        
        private Rigidbody thisRigidbody;

        private Vector2 input;

        private void Awake()
        {
            thisRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            thisRigidbody.MovePosition(thisRigidbody.position +
                                       transform.forward * input.y * moveSpeed * Time.fixedDeltaTime);
            Vector3 yRotation = Vector3.up * input.x * rotationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(yRotation);
            Quaternion targetRotation = thisRigidbody.rotation * deltaRotation;
            thisRigidbody.MoveRotation(Quaternion.Slerp(thisRigidbody.rotation, targetRotation, 50f * Time.deltaTime));
        }
    }
}
