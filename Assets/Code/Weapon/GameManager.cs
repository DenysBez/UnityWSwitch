using UnityEngine;

namespace Lesson
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourceDamage;
        [SerializeField] private AudioSource _audioSourceBlast;

        private static GameManager _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                HealthController.SetAudioSources(_audioSourceDamage, _audioSourceBlast);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}