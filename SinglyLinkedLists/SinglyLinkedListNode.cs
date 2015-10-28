using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        /* start example (notes)
        public string Name { get; set; }
        Two ways to implement get/set method:
        1. C# creates (guesses)
        2. You do it.
        can do: public string Name { get; protected set; }
        */
        
        
        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;

        public SinglyLinkedListNode Next
        {
            get { return next; } //could be get { return next; } {} could contain anything that would go inside a method implementation
            set
            {
                if (this == value)
                {
                    throw new ArgumentException();
                }
                next = value;
            }     
        }
        public override string ToString()
        {
           
            return value.ToString();         
        }

       
        //private static string last;
        private string value;

        public string Value 
        {
            get { return value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value) //this is the constructor
        {

            this.value = value; //arguement named value so use this to not have complier be confused
           
            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsLast()
        {
            //throw new NotImplementedException();
            if (next == null)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            SinglyLinkedListNode node = obj as SinglyLinkedListNode;
            if (node == null)
            {
                return false;
            } else
            {
                return value.Equals(node.value);
            }
        }
    }
}
