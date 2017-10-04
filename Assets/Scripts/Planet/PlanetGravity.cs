using UnityEngine;

namespace Planet
{
    public class PlanetGravity : MonoBehaviour
    {
        public static PlanetGravity Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void ApplyGravity(Rigidbody target, float gravity)
        {
            Vector3 gravityUp = (target.position - transform.position).normalized;
            target.AddForce(gravityUp * -gravity);
            target.MoveRotation(Quaternion.FromToRotation(target.transform.up, gravityUp) * target.rotation);
        }
    }
}
