using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T rootItem)
        {
            this.root = new BinaryNode<T>(rootItem, null ,null);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return this.root;
        }

        public int Size()
        {
            return Size(this.root);
        }

        public int Height()
        {
            return Height(this.root);
        }

        public void MakeEmpty()
        {
            this.root = null;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (t1.root != null && t1.root == t2.root) {
                throw new Exception();
            }

            this.root = new BinaryNode<T>(rootItem, t1.root, t2.root);

            if (this != t1) {
                t1.root = null;
            }

            if (this != t2) {
                t2.root = null;
            }
        }

        public string ToPrefixString()
        {
            string s = "NIL";

            if (this.root != null) {
                return this.root.ToPrefix();
            }

            return s;
        }

        public string ToInfixString()
        {
            string s = "NIL";

            if (this.root != null) {
                return this.root.ToInfix(); 
            }

            return s;
        }

        public string ToPostfixString()
        {
            string s = "NIL";

            if (this.root != null) {
                return this.root.ToPostfix();
            }

            return s;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            return Leaves(this.root);
        }

        public int NumberOfNodesWithOneChild()
        {
            throw new System.NotImplementedException();
        }

        public int NumberOfNodesWithTwoChildren()
        {
            throw new System.NotImplementedException();
        }

        // helpers
        public static int Size(BinaryNode<T> node) {
            if (node == null) {
                return 0;
            }

            return 1 + Size(node.right) + Size(node.left);
        }

        public static int Height(BinaryNode<T> node) {
            if (node == null) {
                return -1;
            }

            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public static int Leaves(BinaryNode<T> node) {
            if (node == null) {
                return 0;
            }

            if (node.left == null && node.right == null) {
                return 1;
            }

            return 0 + Leaves(node.left) + Leaves(node.right);
        }
    }
}