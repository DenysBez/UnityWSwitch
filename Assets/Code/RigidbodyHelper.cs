using UnityEngine;

namespace Lesson
{
    public static class RigidbodyHelper
    {
        public static int Test;

        // public static Rigidbody GetOrAddRigidbody(GameObject gameObject)
        // {
        //     Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        //     if (rigidbody == null)
        //     {
        //         rigidbody = gameObject.AddComponent<Rigidbody>();
        //     }
        //
        //     return rigidbody;
        // }

        public static Rigidbody GetOrAddRigidbody(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
            {
                rigidbody = gameObject.gameObject.AddComponent<Rigidbody>();
            }

            return rigidbody;
        }

        public static string GetName(this string str)
        {
            if (str.Contains("(Clone"))
            {
                return str.Replace("(Clone)", string.Empty);
            }
            
            return str;
        }
        
        public static void Print(this MyClass myClass)
        {
            Debug.Log("Print");
        }
    }

    public class MyClass
    {
        
    }
}
