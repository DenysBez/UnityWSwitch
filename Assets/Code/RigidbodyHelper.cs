using UnityEngine;

namespace Lesson
{
    public static class RigidbodyHelper
    {
        public static Rigidbody GetOrAddRigidbody(this GameObject gameObject)
        {
            if (!gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody = gameObject.AddComponent<Rigidbody>();
            }

            return rigidbody;
        }
    }
}