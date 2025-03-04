using UnityEngine;

namespace Lesson
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Rocket : MonoBehaviour
    {
        private const int COLLISION_SIZE = 128;
        [SerializeField] private float _powerExplosion;
        [SerializeField] private float _scale;

        private Rigidbody _rigidbody;
        private readonly Collider[] _collidedObjects = new Collider[COLLISION_SIZE];
        private static readonly ExplosionFactory _explosionFactory = new(); // Cached static instance

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            _explosionFactory.Create();
            Destroy(gameObject);

            
            float radius = _scale * 0.5f;
            Vector3 center = other.contacts[0].point;
            int countCollided = Physics.OverlapSphereNonAlloc(center, radius, _collidedObjects);
            
            for (int i = 0; i < countCollided; i++)
            {
                Collider collidedObject = _collidedObjects[i];

                if (collidedObject.TryGetComponent(out HealthController healthController))
                {
                    if (!healthController.CanTakeDamage(healthController.MaxHp)) continue;

                    ApplyExplosionForce(healthController, center, radius);
                }
            }
        }

        private void ApplyExplosionForce(HealthController healthController, Vector3 explosionCenter, float explosionRadius)
        {            
            Rigidbody rigidbody = RigidbodyHelper.GetOrAddRigidbody(healthController.gameObject);
            rigidbody.AddExplosionForce(_powerExplosion, explosionCenter, explosionRadius);
        }

        public void Run(Vector3 path)
        {         
            transform.SetParent(null);
            _rigidbody.WakeUp();
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(path, ForceMode.Impulse);
        }

        public void Sleep(Vector3 startPoint)
        {
            _rigidbody.Sleep();
            _rigidbody.isKinematic = true;
            transform.position = startPoint;
        }
    }
}
