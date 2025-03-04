using UnityEngine;

namespace Lesson
{
    public sealed class WeaponController : MonoBehaviour
    {
        private WeaponSelector _weaponSelector;

        private void Start()
        {
            Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
            _weaponSelector = new WeaponSelector(weapons);
        }

        private void Update()
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

            if (scrollWheel >= 0.1f)
            {
                _weaponSelector.Next();
            }
            if (scrollWheel <= -0.1f)
            {
                _weaponSelector.Preview();
            }
            if (Input.GetMouseButton(0))
            {
                _weaponSelector.Fire();
            }

            if (Input.GetMouseButton(1))
            {
                _weaponSelector.Recharge();
            }
        }
    }
}