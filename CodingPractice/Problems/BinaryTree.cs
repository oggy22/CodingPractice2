using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Problems
{
    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left, right;
        BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }

    [TestClass]
    public class BinaryTree : ProblemBase
    {
        public override string Description => "Check if the given binary tree is a binary SEARCH tree.";

        public override Type Input
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Type Output
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Title => "Binary Tree";

        public bool IsBinarySearchTree(BinaryTreeNode root)
        {
            return RecursiveCheck(root, null, null);
        }

        private bool RecursiveCheck(BinaryTreeNode node, int? leftLimit, int? rightLimit)
        {
            if (leftLimit != null && leftLimit >= node.data)
                return false;

            if (rightLimit != null && rightLimit <= node.data)
                return false;

            if (node.left != null)
                if (!RecursiveCheck(node.left, leftLimit, node.data))
                    return false;

            if (node.right != null)
                if (!RecursiveCheck(node.right, node.data, rightLimit))
                    return false;

            return true;
        }
    }
}