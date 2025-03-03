using UnityEngine;

namespace Lesson
{
    public sealed class ExampleStartPoint : MonoBehaviour
    {
        private void Start()
        {
            // RigidbodyHelper rigidbodyHelper = new RigidbodyHelper();
            // rigidbodyHelper.Test = 5;
            RigidbodyHelper.Test = 7;
            
            MyClass myClass = new MyClass();
            myClass.Print();

            Debug.LogError(name.GetName());
            return;
            ExampleCollections exampleCollections = new ExampleCollections();
            exampleCollections.ExampleStack();
            
            return;
            A a = new A();
            a.PrintName();
            
            A ab = new B();
            ab.PrintName();
            
            B b = new B();
            b.PrintName();

           // B bad = new A();
        }
    }
}
