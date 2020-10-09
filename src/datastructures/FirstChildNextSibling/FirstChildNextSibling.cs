using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FCNSNode<T> root;

               public int Size()
        {
            int size = 0;

            if (root != null) {
                size = CheckNodes(root);
            }

            return size;
        }

        public int CheckNodes(FCNSNode<T> node) {
            int size = 0;

            if (node.firstChild != null) {
                size += CheckNodes(node.firstChild);
            }

            if (node.nextSibling != null) {
                size += CheckNodes(node.nextSibling);
            }

            return size + 1;
        }

        public void PrintPreOrder()
        {
            if (root != null) {
                Console.WriteLine(PrintNode(root, ""));
            }
        }

        public string PrintNode(FCNSNode<T> node, string spacing) {
            string s = spacing + node.data.ToString() + "\n";

            if (node.firstChild != null) {
                s += PrintNode(node.firstChild, spacing + "      ") + "\n";
            }

            if (node.nextSibling != null) {
                s += PrintNode(node.nextSibling, spacing) + "\n";
            }

            return s;
        }

        public override string ToString() {

            if (root != null) {
                return PrintString(root);
            }

            return "NIL";
        }

        public string PrintString(FCNSNode<T> node) {
            string s = node.data.ToString();

            if (node.firstChild != null) {
                s += ",FC(" + PrintString(node.firstChild) + ")";
            }

            if (node.nextSibling != null) {
                s += ",NS(" + PrintString(node.nextSibling) + ")";
            }

            return s;
        }
    }
}