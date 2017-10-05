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
        private InputController inputController;
        
        private void Awake()
        {
            thisRigidbody = GetComponent<Rigidbody>();
            inputController = GetComponent<InputController>();
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            thisRigidbody.MovePosition(thisRigidbody.position +
                                       transform.forward * inputController.InputVector.y * moveSpeed * Time.fixedDeltaTime);
        }

        private void Rotate()
        {
            Vector3 yRotation = Vector3.up * inputController.InputVector.x * rotationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(yRotation);
            Quaternion targetRotation = thisRigidbody.rotation * deltaRotation;
            thisRigidbody.MoveRotation(Quaternion.Slerp(thisRigidbody.rotation, targetRotation, 50f * Time.deltaTime));
        }
    }
}
