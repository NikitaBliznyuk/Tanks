using UnityEngine;

namespace Planet
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class GravityBody : MonoBehaviour
    {
        private PlanetGravity planetGravity;
        private Rigidbody thisRigidbody;

        private void Awake()
        {
            planetGravity = PlanetGravity.Instance;
            thisRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            planetGravity.ApplyGravity(thisRigidbody);
        }
    }
}
