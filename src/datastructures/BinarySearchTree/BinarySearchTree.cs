namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Insert(T x)
        {
            BinaryNode<T> node = Insert(this.root, x);
            this.root = node;
        }

        private BinaryNode<T> Insert(BinaryNode<T> node, T x) {
            if (node == null) {
                node = new BinaryNode<T>();
                node.data = x;
            } else if (x.CompareTo(node.data) < 0) {
                node.left = Insert(node.left, x);
            } else if (x.CompareTo(node.data) > 0) {
                node.right = Insert(node.right, x);
            } else {
                throw new BinarySearchTreeDoubleKeyException();
            }

            return node;
        }

        public T FindMin()
        {
            return FindMin(this.root).data;
        }

        private BinaryNode<T> FindMin(BinaryNode<T> node) {
            if (node == null) {
                throw new BinarySearchTreeEmptyException();
            }

            while (node.left != null) {
                node = node.left;
            }

            return node;
        }

        public void RemoveMin()
        {
            if (this.root == null) {
                throw new BinarySearchTreeEmptyException();
            }

            this.root = RemoveMin(this.root);
        }

        private BinaryNode<T> RemoveMin(BinaryNode<T> node) {
            if (node == null) {
                throw new BinarySearchTreeElementNotFoundException();
            }

            if (node.left != null) {
                node.left = RemoveMin(node.left);
                return node;
            } else {
                return node.right;
            }
        }


        public void Remove(T x)
        {
            Remove(this.root, x);
        }

        private BinaryNode<T> Remove(BinaryNode<T> node, T x) {
            if (node == null) {
                throw new BinarySearchTreeElementNotFoundException();
            }

            if (x.CompareTo(node.data) < 0) {
                node.left = Remove(node.left, x);
            } else if (x.CompareTo(node.data) > 0) {
                node.right = Remove(node.right, x);
            } else if (node.left != null && node.right != null) {
                node.data = FindMin(node.right).data;
                node.right = RemoveMin(node.right);
            } else {
                node = node.left ?? node.right;
            }

            return node;
        }

        public override string ToString() {
            return InOrder();
        }

        public string InOrder() {
            if (this.root == null) {
                return "";
            }

            return InOrder(this.root);
        }

        private string InOrder(BinaryNode<T> node) {
            return (node.left != null ? InOrder(node.left) + " " : "") + node.data + (node.right != null ? " " + InOrder(node.right) : "");
        }
    }
}
