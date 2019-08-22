using System;
using System.Collections.Generic;

namespace Project
{
    public class Queue2Stack
    {
        Stack<int> adding = new Stack<int>();
        Stack<int> removing = new Stack<int>();

        // add to queue
        public void Enqueue(int d)
        {
            PushPop(removing, adding);
            adding.Push(d);
        }

        public int Dequeue()
        {
            PushPop(adding, removing);
            return removing.Pop();
        }

        private void PushPop(Stack<int> first, Stack<int> second)
        {
            while (first.Count > 0)
            {
                second.Push(first.Pop());
            }
        }
    }
}