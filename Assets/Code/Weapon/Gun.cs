using System.Collections.Generic;
using UnityEngine;

namespace Lesson
{
    public sealed class Gun : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _countInClip;

        private Transform _bulletRoot;
        private Queue<Bullet> _bullets;

        protected override void Start()
        {
            _bulletRoot = new GameObject("BulletRoot").transform;
            _bullets = new Queue<Bullet>(_countInClip);
            
            base.Start(); // todo: need for recharge dont move  
        }

        public override void Recharge()
        {
            for (int i = 0; i < _countInClip; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, _bulletRoot);
                bullet.Sleep();
                _bullets.Enqueue(bullet);
            }
        }

        public override void Fire()
        {
            if (CanShoot == false)
            {
                return;
            }
            
            if (_bullets.TryDequeue(out Bullet bullet))
            {
                bullet.Run(_barrel.forward * Force, _barrel.position);
                LastShootTime = 0.0f;
            }
        }

        public override void GetInfo()
        {
            base.GetInfo();
            
            Debug.LogError(_countInClip);
        }
    }
}
