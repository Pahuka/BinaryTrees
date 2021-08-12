using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees
{
    public class TreeNode<T> where T : IComparable
    {
        public T value { get; set; }
        public TreeNode<T> Left, Right, Parent;
        private int index = 0;
        private int weight = 1;

        public void LeftIndex()
        {
            var tempNode = Parent;
            while (tempNode != null)
            {
                tempNode.weight += weight;
                tempNode.index = weight;
                tempNode = tempNode.Parent;
            }
        }

        //public bool Contains(T value)
        //{
        //    var result = this.value.CompareTo(value);
        //    if (Left != null) result = Left.value.CompareTo(value);
        //    if (Right != null) result = Right.value.CompareTo(value);
        //    return result == 0 ? true : false;
        //}
    }

    public class BinaryTree<T> where T : IComparable
    {
        private List<TreeNode<T>> nodeList = new List<TreeNode<T>>();
        private TreeNode<T> root = new TreeNode<T>();

        public TreeNode<T> this[int index]
        {
            get
            {
                return nodeList[index];
            }
        }

        public void Add(T value)
        {
            var tempNode = root;
            if (nodeList.Count == 0)
            {
                tempNode.value = value;
                nodeList.Add(tempNode);
            }

            else
            {
                while (tempNode != null)
                {
                    {
                        if (tempNode.value.CompareTo(value) > 0)
                        {
                            if (tempNode.Left == null)
                            {
                                tempNode.Left = new TreeNode<T> { value = value, Parent = tempNode };
                                tempNode.Left.LeftIndex();
                                nodeList.Add(tempNode.Left);
                                break;
                            }
                            tempNode = tempNode.Left;
                        }
                        else if (tempNode.Right == null)
                        {
                            tempNode.Right = new TreeNode<T> { value = value, Parent = tempNode };
                            nodeList.Add(tempNode.Right);
                            break;
                        }
                        else tempNode = tempNode.Right;
                    }
                }
            }
        }

        public bool Contains(T value)
        {
            return nodeList.Select(x => x.value).Contains(value);
        }

        public IEnumerator GetEnumerator()
        {
            return nodeList.GetEnumerator();
        }
    }
}
