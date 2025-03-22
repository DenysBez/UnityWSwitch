using UnityEngine;

namespace Lesson
{
    public sealed class Bazuka : Weapon
    {
        [SerializeField] private Rocket _rocketPrefab;
        private Rocket _instantiateRocket;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public override void Fire()
        {
            if (_instantiateRocket)
            {
                _instantiateRocket.Run(_barrel.forward * Force);
                _instantiateRocket = null;
                if (_audioSource)
                {
                    _audioSource.Play();  // Play the attached AudioClip
                }
            }
        }

        public override void Recharge()
        {
            if (_instantiateRocket == null)
            {
                _instantiateRocket = Instantiate(_rocketPrefab, _barrel);
                _instantiateRocket.Sleep(_barrel.position);
            }
        }
    }
}