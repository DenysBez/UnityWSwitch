using System;
using UnityEngine;
using System.Linq;

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
            var orderedData = _data.OrderByDescending(d => d.Level);
            foreach (var data in orderedData)
            {
                if (data.Level <= level)
                    return data.Data;
            }
            return null;
        }
    }
}