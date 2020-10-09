namespace AD
{
    public partial class FCNSNode<T> : IFCNSNode<T>
    {
        public FCNSNode<T> firstChild;
        public FCNSNode<T> nextSibling;
        public T data;

        public FCNSNode(T data, FCNSNode<T> firstChild, FCNSNode<T> nextSibling)
        {
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
            this.data = data;
        }

        public FCNSNode(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return this.data;
        }

        public FCNSNode<T> GetFirstChild()
        {
            return this.firstChild;
        }

        public FCNSNode<T> GetNextSibling()
        {
            return this.nextSibling;
        }
    }
}