using UnityEngine;

namespace Lesson.Sound
{
    public class FootstepSound : MonoBehaviour
    {
        [SerializeField] private GameObject footstepAudioObject;
        private AudioSource footstepAudio;
        private Vector3 lastPosition;

        [SerializeField] private float stepInterval = 0.5f;
        private float nextStepTime = 0f;

        void Start()
        {
            if (footstepAudioObject != null)
            {
                footstepAudio = footstepAudioObject.GetComponent<AudioSource>();
            }

            if (footstepAudio == null || footstepAudio.clip == null)
            {
                Debug.LogError("FootstepSound: No valid AudioSource or AudioClip assigned");
            }

            lastPosition = transform.position;
        }

        void Update()
        {
            float distanceMoved = (transform.position - lastPosition).magnitude;
            bool isMoving = distanceMoved > 0.01f;

            if (isMoving && Time.time >= nextStepTime)
            {
                PlayFootstep();
                nextStepTime = Time.time + stepInterval;
            }

            lastPosition = transform.position;
        }

        private void PlayFootstep()
        {
            if (!footstepAudio.isPlaying)
            {
                footstepAudio.Play();
            }
        }
    }
}