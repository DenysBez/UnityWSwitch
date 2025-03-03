using UnityEngine;

namespace Lesson
{
    public sealed class ExplosionFactory
    {
        public Explosion Create()
        {
            return new GameObject().AddComponent<Explosion>();
        }
    }
}
