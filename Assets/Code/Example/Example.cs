
using UnityEngine;

namespace Lesson
{
    public abstract class ExampleAbstractClass
    {
        
    }

    public sealed class ExampleSealedClass
    {
    }


    public class A
    {
        public virtual void PrintName()
        {
            Debug.LogError(nameof(A));
        }
    }

    public class B : A
    {
        public override void PrintName()
        {
            Debug.LogError(nameof(B));
        }
    }
    
    
    
    public class ExampleMonoBehaviour : MonoBehaviour
    {
        public ExampleMonoBehaviour() // dont override constructors in MonoBehaviour
        {
            
        }
    }
}
