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
        public int weight = 1;

        public void UpDate()
        {
            if (this.value.CompareTo(value) <= 0) ;

            //var tempNode = Parent;
            //while (tempNode != null)
            //{
            //    if (tempNode.value.CompareTo(value) > 0)
            //    {
            //        Parent.index = weight;
            //        Parent.weight++;
            //    }
            //    else
            //    {
            //        index = Parent.index + 1;
            //        Parent.weight++;
            //    }
            //    tempNode = tempNode.Parent;
            //}
        }

        public bool Contains(T value)
        {
            var result = this.value.CompareTo(value);
            if (result == 0) return true;
            else if (result > 0 && Left != null) return Left.Contains(value);
            else if (result < 0 && Right != null) return Right.Contains(value);
            else return false;
        }
    }

    public class BinaryTree<T> where T : IComparable
    {
        private List<TreeNode<T>> nodeList = new List<TreeNode<T>>();
        private TreeNode<T> root = new TreeNode<T>() { weight = 0 };

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
            if (tempNode.weight == 0)
            {
                tempNode.value = value;
                tempNode.weight++;
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
                            tempNode.Left.UpDate();
                            break;
                        }
                        tempNode = tempNode.Left;
                    }
                    else if (tempNode.Right == null)
                    {
                        tempNode.Right = new TreeNode<T> { value = value, Parent = tempNode };
                        tempNode.Right.UpDate();
                        break;
                    }
                    else tempNode = tempNode.Right;
                }
            }
        }

        public bool Contains(T value)
        {
            if (root.weight == 0) return false;
            else return root.Contains(value);
        }

        public IEnumerator GetEnumerator()
        {
            return nodeList.Select(x => x.value).OrderBy(x => x).GetEnumerator();
        }
    }
}
