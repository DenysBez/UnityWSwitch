using UnityEngine;
using System.Collections;

namespace Lesson.Sound
{
    public class FootstepSound : MonoBehaviour
    {
        private AudioSource footstepAudio;
        private Vector3 lastPosition;
        private Coroutine footstepCoroutine;

        void Start()
        {
            lastPosition = transform.position;

            // Get the correct AudioSource from Main Camera
            AudioSource[] audioSources = Camera.main.GetComponents<AudioSource>();
            foreach (AudioSource source in audioSources)
            {
                if (source.clip != null && source.clip.name == "steps")
                {
                    footstepAudio = source;
                    break;
                }
            }
        }

        void Update()
        {
            float distanceMoved = (transform.position - lastPosition).magnitude;

            if (distanceMoved > 0.01f) 
            {
                if (footstepCoroutine == null)
                {
                    footstepCoroutine = StartCoroutine(PlayFootstepLoop());
                }
            }
            else
            {
                if (footstepCoroutine != null)
                {
                    StopCoroutine(footstepCoroutine);
                    footstepCoroutine = null;
                    footstepAudio.Stop();
                }
            }

            lastPosition = transform.position;
        }

        IEnumerator PlayFootstepLoop()
        {
            while (true)
            {
                if (!footstepAudio.isPlaying)
                {
                    footstepAudio.Play();
                }
                yield return new WaitForSeconds(footstepAudio.clip.length);
            }
        }
    }
}