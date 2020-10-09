using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        List<T> queue;

        public MyQueue() {
            this.Clear();
        }

        public bool IsEmpty()
        {
            return this.queue.Count == 0;
        }

        public void Enqueue(T data)
        {
            this.queue.Add(data);
        }

        public T GetFront()
        {
            if (this.IsEmpty()) {
                throw new MyQueueEmptyException();
            }

            return this.queue[0];
        }

        public T Dequeue()
        {
            if (this.IsEmpty()) {
                throw new MyQueueEmptyException();
            }

            T data = this.GetFront();
            this.queue.RemoveAt(0);
            return data;
        }

        public void Clear()
        {
            this.queue = new List<T>();
        }

    }
}