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
        public int Weight = 1;
        
        public bool Contains(T value)
        {
            var result = this.value.CompareTo(value);
            if (result == 0) return true;
            else if (result > 0 && Left != null) return Left.Contains(value);
            else if (result < 0 && Right != null) return Right.Contains(value);
            else return false;
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        private SortedList<T, int> nodeList = new SortedList<T, int>();
        private TreeNode<T> root = new TreeNode<T>() { Weight = 0 };

        public T this[int index]
        {
            get
            {
                return nodeList.Keys[index];
            }
        }

        public void Add(T value) 
        {
            var tempNode = root;
            if (root.Weight == 0)
            {
                tempNode.value = value;
                tempNode.Weight++;
                nodeList.Add(value, 0);
            }

            else
            {
                while (tempNode != null)
                {
                    if (tempNode.value.CompareTo(value) > 0)
                    {
                        if (tempNode.Left == null)
                        {
                            tempNode.Left = new TreeNode<T> { value = value, Parent = tempNode };
                            nodeList.Add(value, 0);
                            break;
                        }
                        tempNode = tempNode.Left;
                    }
                    else if (tempNode.Right == null)
                    {
                        tempNode.Right = new TreeNode<T> { value = value, Parent = tempNode };
                        nodeList.Add(value, 0);
                        break;
                    }
                    else tempNode = tempNode.Right;
                }
            }
        }

        public bool Contains(T value)
        {
            if (root.Weight == 0) return false;
            else return root.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return nodeList.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
