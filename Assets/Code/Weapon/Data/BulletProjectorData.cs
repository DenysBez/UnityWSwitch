using UnityEngine;

namespace Lesson
{
    [CreateAssetMenu(fileName = nameof(BulletProjectorData), menuName = "Data/Weapon/BulletProjectorData")]
    public sealed class BulletProjectorData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Material _material;
        [SerializeField] private float _lightRange = 0.4f; 
        [SerializeField] private float _lightIntensity = 0.02f; 
        [SerializeField] private float _lightInnerSpotAngle = 7.0f;
        [SerializeField] private float _lightSpotAngle = 30.0f;

        public Material Material => _material;
        public float LightRange => _lightRange;
        public float LightIntensity => _lightIntensity;
        public float LightInnerSpotAngle => _lightInnerSpotAngle;
        public float LightSpotAngle => _lightSpotAngle;
    }
}