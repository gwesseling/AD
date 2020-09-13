namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            if (size >= data.Length) {
                throw new MyArrayListFullException();
            }

            data[size] = n;
            size++;
        }

        public int Get(int index)
        {
            if (index < 0 || size == 0|| index > (size - 1)) {
                throw new MyArrayListIndexOutOfRangeException();
            }

            return data[index];
        }

        public void Set(int index, int n)
        {
            if (index < 0 || index > (size - 1)) {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            data = new int[data.GetLength(0)];
            size = 0;
        }

        public int CountOccurences(int n)
        {
            int occurences = 0;

            for (int i = 0; i < data.Length; i++) {
                if (data[i] == n) {
                    occurences++;
                }
            }

            return occurences;
        }

        public override string ToString() {
            string result = "NIL";

            if (size > 0) {
                result = "[";
                for (int i = 0; i < size; i++) {
                    result += data[i];

                    if (i < size - 1) {
                        result += ",";
                    }
                }
                result += "]";
            }

            return result;
        }
    }
}
