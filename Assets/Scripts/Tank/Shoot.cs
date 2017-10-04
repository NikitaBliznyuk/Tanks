using System.Linq;
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
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3.0f);
            if(colliders.Length == 0)
                return;

            foreach (var collider in colliders)
            {
                IVulnerable vulnerable = collider.GetComponent<IVulnerable>();
                if(vulnerable == null)
                    continue;
                
                vulnerable.DealDamage(Damage * Mathf.InverseLerp(3.0f, 0.0f,
                                          Vector3.Distance(collider.transform.position, transform.position)));
            }

            Destroy(gameObject);
        }
    }
}
