using System.Collections;
using UnityEngine;

namespace Lesson
{
    public sealed class Explosion : MonoBehaviour
    {
        private Light _light;

        private void Awake()
        {
            _light = gameObject.AddComponent<Light>();
            _light.type = LightType.Point;

            if (ColorUtility.TryParseHtmlString("#FFE700", out var color))
            {
                _light.color = color;
            }
        }

        private IEnumerator Start()
        {
            _light.transform.SetParent(null);
            const float step = 1.5f;

            while (_light.intensity < 10)
            {
                _light.intensity += step;
                _light.range += step;
                yield return new WaitForSeconds(0.05f);
            }

            Destroy(gameObject);
        }
    }
}