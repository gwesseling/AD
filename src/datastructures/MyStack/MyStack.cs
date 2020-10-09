namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        MyLinkedList<T> linkedlist;

        public MyStack() { 
            this.linkedlist = new MyLinkedList<T>();
        }

        public bool IsEmpty()
        {
            return this.linkedlist.Size() == 0;
        }

        public T Pop()
        {
            if (this.IsEmpty()) {
                throw new MyStackEmptyException();
            }

            T data = this.linkedlist.GetFirst();
            this.linkedlist.RemoveFirst();
            return data;
        }

        public void Push(T data)
        {
            this.linkedlist.AddFirst(data);
        }

        public T Top()
        {
            if (this.IsEmpty()) {
                throw new MyStackEmptyException();
            }

            return this.linkedlist.head.data;
        }
    }
}
