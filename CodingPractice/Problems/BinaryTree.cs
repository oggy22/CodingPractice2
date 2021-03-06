﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Problems
{
    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left, right;
        public BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        public BinaryTreeNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }

    [TestClass]
    public class BinaryTree : ProblemBaseT<BinaryTreeNode, bool>
    {
        public override string Description => "Check if the given binary tree is a binary SEARCH tree.";

        public override string Title => "Binary Tree";

        protected override IEnumerable<Tuple<BinaryTreeNode, bool>> TestCases
        {
            get
            {
                yield return new Tuple<BinaryTreeNode, bool>(new BinaryTreeNode(10), true);
            }
        }

        public override bool Solve(BinaryTreeNode root)
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