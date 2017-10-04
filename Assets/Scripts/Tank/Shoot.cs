using Planet;
using UnityEngine;

namespace Tank.Shoot
{
    [RequireComponent(typeof(GravityBody))]
    public class Shoot : MonoBehaviour
    {
        public GravityBody GravityBody { get; private set; }

        private void Awake()
        {
            GravityBody = GetComponent<GravityBody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);

            if (!other.collider.CompareTag("Environment"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
