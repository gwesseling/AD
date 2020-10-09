using System.Collections.Generic;


namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            for (int gap = list.Count / 2; gap > 0; gap = gap == 2 ? 1 : (int) (gap / 2.2)) {
                for (int i = gap; i < list.Count; i++) {
                    int tmp = list[i];
                    int j = i;

                    for (; j >= gap && tmp.CompareTo(list[j - gap]) < 0; j -= gap) {
                        list[j] = list[j - gap];
                    }

                    list[j] = tmp;
                }
            }
        }
    }
}
