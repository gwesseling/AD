using System.Collections.Generic;


namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        public override void Sort(List<int> list)
        {
            Sort(list, 0, list.Count - 1);
        }

        private static void Sort(List<int> list, int low, int high) {
            if (low + CUTOFF > high) {
                new InsertionSort().Sort(list);
            } else {
                int middle = (low + high) / 2;
                if (list[middle].CompareTo(list[low]) < 0) {
                    SwapReferences(list, low, middle);
                }

                if (list[high].CompareTo(list[low]) < 0) {
                    SwapReferences(list, low, high);
                }

                if (list[high].CompareTo(list[middle]) < 0) {
                    SwapReferences(list, middle, high);
                }

                SwapReferences(list, middle, high - 1);
                int pivot = list[high - 1];

                int i, j;
                for (i = low, j = high - 1; ;) {
                    while (list[++i].CompareTo(pivot) < 0) {
                        ;
                    }

                    while (pivot.CompareTo(list[--j]) < 0) {
                        ;
                    }

                    if (i >= j) {
                        break;
                    }

                    SwapReferences(list, i, j);
                }

                SwapReferences(list, i, high - 1);

                Sort(list, low, i - 1);
                Sort(list, i + 1, high);
            }
        }

        private static void SwapReferences(List<int> list, int i, int j) {
            int tmpi = list[i];
            int tmpj = list[j];

            list[i] = tmpj;
            list[j] = tmpi;
        }
    }
}
