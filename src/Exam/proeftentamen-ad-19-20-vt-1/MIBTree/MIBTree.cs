namespace AD
{
    public class MIBTree : BinarySearchTree<MIBNode>
    {
        public MIBTree()
        {
            Insert(new MIBNode("1.3.6.1.4.1.9", "cisco"));
            Insert(new MIBNode("1.3.6.1.1.1.1", "system"));
            Insert(new MIBNode("1.3.6", "dod"));
            Insert(new MIBNode("1.3.6.1.1.1.4", "ip"));
            Insert(new MIBNode("1.3.6.1.3", "experimental"));
            Insert(new MIBNode("1.3.6.1.4.1", "enterprise"));
            Insert(new MIBNode("1.3.6.1.1.1.2", "interfaces"));
            Insert(new MIBNode("1.3.6.1.1", "directory"));
            Insert(new MIBNode("1.3", "org"));
            Insert(new MIBNode("1.3.6.1.4.1.2636", "juniperMIB"));
            Insert(new MIBNode("1.3.6.1.4.1.311", "microsoft"));
            Insert(new MIBNode("1.3.6.1", "internet"));
            Insert(new MIBNode("1", "iso"));
            Insert(new MIBNode("1.3.6.1.4", "private"));
            Insert(new MIBNode("1.3.6.1.1.1", "mib-2"));
            Insert(new MIBNode("1.3.6.1.2", "mgmt"));
        }

        public MIBNode FindNode(string oid)
        {
            return CheckNode(this.root, oid);
        }

        public MIBNode CheckNode(BinaryNode<MIBNode> node, string oid) {
            MIBNode found = null;

            if (node.data.oid.Equals(oid)) {
                found = node.data;
            }

            if (found == null && node.left != null) {
                found = CheckNode(node.left, oid);
            }

            if (found == null && node.right != null) {
                found = CheckNode(node.right, oid);
            } 
  
            return found;
        }

        public bool AllNodesAvailable(string oid) {
            if (this.FindNode(oid) != null) {
                string[] split = oid.Split(".");
                int length = oid.Length - split[split.Length - 1].Length - 1;

                if (length > 0) {
                    return this.AllNodesAvailable(oid.Substring(0, length));
                }

                return true;
            } 

            return false;
        }

        /* public bool AllNodesAvailable(string oid)
         {
             string[] split = oid.Split(".");
             int count = CheckNodeName(this.root, oid);

             if (count == split.Length) {
                 return true;
             }

             return false;
         }*/

        /* public int CheckNodeName(BinaryNode<MIBNode> node, string oid) {
             if (node == null) {
                 return 0;
             }

             return (oid.Contains(node.data.oid) ? 1 : 0) + (node.left != null ? CheckNodeName(node.left, oid) : 0) + (node.right != null ? CheckNodeName(node.right, oid) : 0);
         }*/
    }
}
