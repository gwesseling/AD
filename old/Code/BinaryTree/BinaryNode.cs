namespace AD
{
    public partial class BinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default(T), default(BinaryNode<T>), default(BinaryNode<T>)) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public string ToPrefix() {
            return "[ " + this.data.ToString() + " " + (this.left != null ? this.left.ToPrefix() : "NIL") + " " + (this.right != null ? this.right.ToPrefix() : "NIL") + " ]";
        }

        public string ToInfix() {
            return "[ " + (this.left != null ? this.left.ToInfix() : "NIL") + " " + this.data.ToString() + " " + (this.right != null ? this.right.ToInfix() : "NIL") + " ]";
        }

        public string ToPostfix() {
            return "[ " + (this.left != null ? this.left.ToPostfix() : "NIL") + " " + (this.right != null ? this.right.ToPostfix() : "NIL") + " " + this.data.ToString() + " ]";
        }
    }
}