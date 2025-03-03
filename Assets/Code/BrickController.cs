using UnityEngine;

namespace Lesson
{
    public sealed class BrickController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                BrickComponent[] findObjectsByType = FindObjectsByType<BrickComponent>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                
                foreach (var brickComponent in findObjectsByType)
                {
                    if (Random.Range(0, 100) < 30)
                    {
                        Destroy(brickComponent.gameObject);
                    }
                }
            }
        }
    }
}
