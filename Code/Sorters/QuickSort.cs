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
            int middle = (low + high) / 2;
            if (list[middle].CompareTo(list[low]) < 0) { 
                
            }
        }
    }
}
