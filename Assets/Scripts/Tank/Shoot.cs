using Planet;
using UnityEngine;

namespace Tank.Shoot
{
    [RequireComponent(typeof(GravityBody))]
    public class Shoot : MonoBehaviour
    {
        public GravityBody GravityBody { get; private set; }
        public float Damage { get; set; }

        private void Awake()
        {
            GravityBody = GetComponent<GravityBody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);

            IVulnerable obj = other.collider.GetComponent<IVulnerable>();

            if (obj == null)
                return;

            obj.DealDamage(Damage);
        }
    }
}
