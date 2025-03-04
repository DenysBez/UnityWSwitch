using System.Collections;
using UnityEngine;

namespace Lesson
{
    public sealed class HealthController : MonoBehaviour
    {
        [SerializeField] private float _health = 3.0f;
        [SerializeField] private float _lifeTime = 5.0f;

        private bool _isAlive = true;
        private float _maxHp;

        public float MaxHp => _maxHp;

        private void Start()
        {
            _maxHp = _health;
        }
        
        public bool CanTakeDamage(float damage)
        {
            if (!_isAlive) return false;

            _health -= damage;

            if (_health <= 0)
            {
                StartCoroutine(Die());
                _isAlive = false;
                return false;
            }

            return true;
        }

        public bool CanAddHealth(int health)
        {
            if (!_isAlive || _health >= _maxHp) return false;

            _health += health;
            return true;
        }

        private IEnumerator Die()
        {
            var renderer = GetComponent<Renderer>();
            
            yield return FlashColor(renderer, Color.red, 1.0f);
            yield return FlashColor(renderer, Color.green, 1.0f);
            yield return FlashColor(renderer, Color.red, 1.0f);
            yield return FlashColor(renderer, Color.green, 1.0f);
            yield return FlashColor(renderer, Color.red, 0);

            yield return new WaitForSeconds(_lifeTime);

            StartCoroutine(Fade());
        }

        private IEnumerator FlashColor(Renderer renderer, Color color, float waitTime)
        {
            renderer.material.color = color;
            yield return new WaitForSeconds(waitTime);
        }

        private IEnumerator Fade()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                Color color = renderer.material.color;
                for (float alpha = 1.0f; alpha >= 0; alpha -= 0.1f)
                {
                    color.a = alpha;
                    renderer.material.color = color;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            
            Destroy(gameObject);
        }
    }
}
