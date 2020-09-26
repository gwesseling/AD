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
            string s = "[ " + this.data.ToString();

            if (this.left != null) {
                s += " " + this.left.ToPrefix();
            } else {
                s += " NIL";
            }

            if (this.right != null) {
                s += " " + this.right.ToPrefix();
            } else {
                s += " NIL";
            }

            return s + " ]";
        }

        public string ToInfix() {
            string s = "[";

            if (this.left != null) {
                s += " " + this.left.ToInfix();
            } else {
                s += " NIL";
            }

            s += " " + this.data.ToString();

            if (this.right != null) {
                s += " " + this.right.ToInfix();
            } else {
                s += " NIL";
            }

            return s + " ]";
        }

        public string ToPostfix() {
            string s = "[";

            if (this.left != null) {
                s += " " + this.left.ToPostfix();
            } else {
                s += " NIL";
            }

            if (this.right != null) {
                s += " " + this.right.ToPostfix();
            } else {
                s += " NIL";
            }

            return s + " " + this.data.ToString() + " ]";
        }
    }
}