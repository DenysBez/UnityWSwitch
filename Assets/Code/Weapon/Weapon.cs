using UnityEngine;

namespace Lesson
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _level;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected WeaponUpgradeData _upgradeData;

        protected float Force { get; private set; }
        protected bool CanShoot => _shotDelay <= LastShootTime;
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
            if (!CanShoot)
            {
                LastShootTime += Time.deltaTime;
            }
        }

        public abstract void Fire();

        public abstract void Recharge();

        public virtual void GetInfo()
        {
            Debug.Log($"Weapon Shot Delay: {_shotDelay}");
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public float GetRemainingTimeToShoot()
        {
            return Mathf.Max(0f, _shotDelay - LastShootTime);
        }

        public void UpgradeWeapon()
        {
            WeaponData weaponData = _upgradeData.GetWeaponData(_level);
            _shotDelay = weaponData.ShotDelay;
            Force = weaponData.Force;
        }
    }
}