using UnityEngine;

namespace Lesson
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _level;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected WeaponUpgradeData _upgradeData;

        protected float Force { get; private set; }
        protected bool CanShoot { get; private set; }
        protected float LastShootTime { get; set; }

        private float _shotDelay;

        protected virtual void Start()
        {
            WeaponData weaponData = _upgradeData.GetWeaponData(_level);

            _shotDelay = weaponData.ShotDelay;
            Force = weaponData.Force;
            
            Recharge();
        }

        private void Update()
        {
            CanShoot = _shotDelay <= LastShootTime;

            if (CanShoot)
            {
                return;
            }

            LastShootTime += Time.deltaTime;
        }

        public abstract void Fire();

        public abstract void Recharge();

        public virtual void GetInfo()
        {
            Debug.LogError(_shotDelay);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
