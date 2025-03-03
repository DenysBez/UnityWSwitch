using System;
using UnityEngine;

namespace Lesson
{
    [CreateAssetMenu(fileName = nameof(WeaponUpgradeData), menuName = "Data/Weapon/Upgrade")]
    public sealed class WeaponUpgradeData : ScriptableObject
    {
        [Serializable]
        private sealed class WeaponDataByLevel
        {
            public int Level;
            public WeaponData Data;
        }

        [SerializeField] private WeaponDataByLevel[] _data;
        
        public WeaponData GetWeaponData(int level)
        {
            for (var index = 0; index < _data.Length; index++)
            {
                WeaponDataByLevel data = _data[index];
                if (data.Level == level)
                {
                    return data.Data;
                }
            }

            return null; // DZ 
        }
    }
}
