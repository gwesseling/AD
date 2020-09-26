using System.Collections.Generic;


namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            List<int> tmpArray = new List<int>();
            Sort(list, tmpArray, 0, list.Count - 1);
        }

        private static void Sort(List<int> list, List<int> tmpArray, int left, int right) {
            if (left < right) {
                int center = (left + right) / 2;
                Sort(list, tmpArray, left, center);
                Sort(list, tmpArray, center + 1, right);
                Merge(list, tmpArray, left, center + 1, right);
            }
        }

        private static void Merge(List<int> list, List<int> tmpArray, int left, int right, int rightEnd) {
            int leftEnd = right - 1;
            int tmp = left;
            int numElements = rightEnd - left + 1;

            while (left <= leftEnd && right <= rightEnd) {
                if (list[left].CompareTo(list[right]) <= 0) {
                    tmpArray[tmp++] = list[left++];
                } else {
                    tmpArray[tmp++] = list[right++];
                }
            }

            while (left <= leftEnd) {
                tmpArray[tmp++] = list[left++];
            }

            while (right <= rightEnd) {
                tmpArray[tmp++] = list[right++];
            }

            for (int i = 0; i < numElements; i++, rightEnd--) {
                list[rightEnd] = tmpArray[rightEnd];
            }
        }

    }
}
