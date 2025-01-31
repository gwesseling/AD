﻿namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            this.data = new int[capacity];
            this.size = 0;
        }

        public void Add(int n)
        {
            if (this.size >= this.data.Length) {
                throw new MyArrayListFullException();
            }

            this.data[size] = n;
            this.size++;
        }

        public int Get(int index)
        {
            if (index < 0 || this.size == 0|| index > (size - 1)) {
                throw new MyArrayListIndexOutOfRangeException();
            }

            return this.data[index];
        }

        public void Set(int index, int n)
        {
            if (index < 0 || index > (this.size - 1)) {
                throw new MyArrayListIndexOutOfRangeException();
            }

            this.data[index] = n;
        }

        public int Capacity()
        {
            return this.data.Length;
        }

        public int Size()
        {
            return this.size;
        }

        public void Clear()
        {
            this.data = new int[this.data.GetLength(0)];
            this.size = 0;
        }

        public int CountOccurences(int n)
        {
            int occurences = 0;

            for (int i = 0; i < this.data.Length; i++) {
                if (this.data[i] == n) {
                    occurences++;
                }
            }

            return occurences;
        }

        public override string ToString() {
            string result = "NIL";

            if (this.size > 0) {
                result = "[";
                for (int i = 0; i < this.size; i++) {
                    result += this.data[i];

                    if (i < this.size - 1) {
                        result += ",";
                    }
                }
                result += "]";
            }

            return result;
        }
    }
}
