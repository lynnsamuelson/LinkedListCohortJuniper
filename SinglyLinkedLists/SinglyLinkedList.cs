﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;
        private SinglyLinkedListNode lastNode;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        private SinglyLinkedList next;

        public string this[int i]
        {
            get { return next.ToString(); }
            set {
                if (this.ToString() == value)
                {
                    throw new ArgumentException();
                }
                next = this;
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if (null == firstNode)
            {
                firstNode = new SinglyLinkedListNode(value);
                lastNode = firstNode;
            }
            else
            {
                lastNode.Next = new SinglyLinkedListNode(value);
                lastNode = lastNode.Next;
                    //Actually attach new node to the end of the list.
            }              
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode theNode = firstNode;
            
            for (int i = 0; i <= index; i++)
            {
                if (theNode == null)
                {
                    throw new ArgumentOutOfRangeException();

                } else if (i == index)
                   
                {
                    return theNode.ToString();
                    
                }
                theNode = theNode.Next;
            }
                return theNode.ToString();       
        }
       
        public string First()
        {
            if (null == firstNode) //null first will help if you have trouble with remembering ==
            {
                return null;
            } else
            {
                return firstNode.Value;          
            }
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {

            if (lastNode == null)
            {
                return null;
            } else
            {
                return lastNode.Value.ToString();
            }
        }

        public override string ToString()
        {
            string final = " ";
            if (firstNode != null)
            {
                SinglyLinkedListNode nodes = firstNode;
                while (!firstNode.IsLast())
                {
                    final += "\"" + nodes.Value.ToString() + "\", ";
                    nodes = nodes.Next;
                }
                final += "\"" + nodes.Value.ToString() + "\" ";
            }
                return "{" + final + "}";
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
