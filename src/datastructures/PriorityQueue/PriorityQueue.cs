using System;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
         public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            this.array = new T[DEFAULT_CAPACITY + 1];
            this.size = 0;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return this.size;
        }

        public void Clear()
        {
            this.size = 0;
        }

        public void Add(T x)
        {
            if (size + 1 == array.Length) {
                DoubleArray();
            }

            PopulateUp(x);
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            T item = Element();
            array[1] = array[size--];
            PercolateDown(1);
            return item;
        }

        public override string ToString() {
            string s = "";

            for (int i = 1; i < size + 1; i ++) {
                s += (i > 1 ? " " : "") + array[i].ToString();
            }

            return s;
        }


        /* 
         * Helpers
         */
        public void DoubleArray() {
            T[] old = array;
            this.array = new T[size * 2 + 1];

            for (int i = 0; i < size + 1; i++) {
                this.array[i] = old[i];
            }
        }

        public void PopulateUp(T x) {
            int hole = ++size;
            array[0] = x;

            for (; Compare(x, array[hole / 2]) < 0; hole /= 2) {
                array[hole] = array[hole / 2];
            }

            array[hole] = x;
        }

        public void PercolateDown(int hole) {
            int child;
            T tmp = array[hole];

            for (; hole * 2 <= size; hole = child) {
                child = hole * 2;

                if (child != size && Compare(array[child + 1], array[child]) < 0) {
                    child++;
                }

                if (Compare(array[child], tmp) < 0) {
                    array[hole] = array[child];
                } else {
                    break;
                }
            }

            array[hole] = tmp;
        }

        public T Element() {
            if (IsEmpty()) {
                throw new PriorityQueueEmptyException();
            }

            return array[1];
        }

        public bool IsEmpty() {
            return size == 0;
        }

        private int Compare(T lhs, T rhs) {
            return lhs.CompareTo(rhs);
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            this.array[size] = x;
            size++;
        }

        public void BuildHeap()
        {
            for (int i = size / 2; i > 0; i--) {
                PercolateDown(i);
            }
        }
    }
}
