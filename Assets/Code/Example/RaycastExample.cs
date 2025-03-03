using UnityEngine;

namespace Lesson
{
    public sealed class RaycastExample : MonoBehaviour
    {
        [SerializeField] private float _distance = 10.0f;
        
        private RaycastHit[] _hitResults = new RaycastHit[5];
        
        private void Update()
        {
            Fourth();
            Debug.DrawRay(transform.position, transform.forward * _distance, Color.red);
        }

        private void First()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _distance))
            {
                Debug.LogError(hit.collider.name); 
            }
        }
        
        private void Second()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _distance))
            {
                Debug.LogError(hit.collider.name);
            }
        }
        
        private void Third()
        {
            if (Input.GetMouseButton(0) == false)
            {
                return;
            }
            
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

            if (Physics.Raycast(ray, out RaycastHit hit, _distance))
            {
                Debug.LogError(hit.collider.name);
            }
        }
        
        private void Fourth()
        {
            int hits = Physics.RaycastNonAlloc(transform.position, transform.forward, _hitResults, _distance);
            for (int i = 0; i < hits; i++)
            {
                Debug.Log("Hit " + _hitResults[i].collider.name);
            }
            
            if (hits == 0)
            {
                Debug.Log("Did not hit");
            }
        }
    }
}
