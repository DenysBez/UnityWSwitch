using System.Collections.Generic;
using UnityEngine;

namespace Lesson
{
    public sealed class ExampleCollections
    {
        public void ExampleList()
        {
            List<int> list = new List<int>();
            
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);

            int i = list[1];

            int GetItem(int index)
            {
                return list[index];
            }
        }

        public void ExampleQueue()
        {
            Queue<int> queue = new Queue<int>();
            
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            
            int one = queue.Dequeue();
            Debug.LogError(one);
            
            int two = queue.Dequeue();
            Debug.LogError(two);
            
            int three = queue.Dequeue();
            Debug.LogError(three);
            
            int four = queue.Dequeue();
            Debug.LogError(four);
            
            int five = queue.Dequeue();
            Debug.LogError(five);
        }
        
        public void ExampleStack()
        {
            Stack<int> stack = new Stack<int>();
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            
            int five = stack.Pop();
            Debug.LogError(five);
            
            int four = stack.Pop();
            Debug.LogError(four);
            
            int three = stack.Pop();
            Debug.LogError(three);
            
            int two = stack.Pop();
            Debug.LogError(two);
            
            int one = stack.Pop();
            Debug.LogError(one);
        }
    }
}
