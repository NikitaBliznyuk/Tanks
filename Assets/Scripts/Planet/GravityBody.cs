using UnityEngine;

namespace Planet
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class GravityBody : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private float gravity = 9.8f;
        
        private PlanetGravity planetGravity;
        
        public Rigidbody ThisRigidbody { get; private set; }

        private void Awake()
        {
            planetGravity = PlanetGravity.Instance;
            ThisRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            planetGravity.ApplyGravity(ThisRigidbody, gravity);
        }
    }
}
