using System.Collections.Generic;


namespace AD
{
    public partial class InsertionSort : Sorter
    {
       public override void Sort(List<int> list)
       {
            for (int p = 1; p < list.Count; p++) {
                int tmp = list[p];
                int j = p;

                for (; j > 0 && tmp.CompareTo(list[j - 1]) < 0; j--) {
                    list[j] = list[j - 1];
                }

                list[j] = tmp;
            }
        }
    }
}
