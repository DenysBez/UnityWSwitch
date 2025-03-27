using UnityEngine;

namespace Lesson
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject audioHolder;

        private void Awake()
        {
            HealthController.SetAudioHolder(audioHolder);
        }
    }
}