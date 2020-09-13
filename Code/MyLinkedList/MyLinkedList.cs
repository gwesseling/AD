namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> head;
        private int size;

        public MyLinkedList()
        {
            this.size = 0;
        }

        public void AddFirst(T data)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>() {
                data = data
            };

            if (size > 0) {
                node.next = head;
            }

            this.head = node;
            this.size++;
        }

        public T GetFirst()
        {
            if (size == 0) {
                throw new MyLinkedListEmptyException();
            }

            return this.head.data;
        }

        public void RemoveFirst()
        {

            if (size == 0) {
                throw new MyLinkedListEmptyException();
            }

            MyLinkedListNode<T> node = head.next;
            head = node;
            size--;
        }

        public int Size()
        {
            return this.size;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > size) {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            MyLinkedListNode<T> prevNode = null;
            MyLinkedListNode<T> node = head;
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>() {
                data = data,
                next = null,
            };

            for (int i = 0; i < index + 1; i++) {
                if (i == index) {
                    if (i == 0) {
                        this.head = newNode;
                    }

                    if (prevNode != null) {
                        newNode.next = prevNode.next;
                        prevNode.next = newNode;
                    }
                    size++;
                }

                if (node != null) {
                    prevNode = node;
                    node = node.next;
                }
            }
        }

        public override string ToString()
        {
            string result = "NIL";

            if (size > 0) {
                result = "[";

                MyLinkedListNode<T> node = head;
                for (int i = 0; i < size; i++) {
                    result += node.data;

                    if (i < size - 1) {
                        result += ",";
                    }

                    node = node.next;
                }

                result += "]";
            }

            return result;
        }
    }
}