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
            set { this.value = value; }
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
        public int CompareTo(Object obj1)
        {
            //throw new NotImplementedException();
            if (obj1 == null)
            {
                throw new Exception("node 2 is null");
            }

            SinglyLinkedListNode node2 = obj1 as SinglyLinkedListNode;
            if (obj1 != null)
            {                
                return (this.value.CompareTo(obj1.ToString()));
            } else
            {
                throw new Exception("this did not work");
            }
        }

        public override int GetHashCode()
        {
                return this.Value.GetHashCode();
 
        }

        public bool IsLast()
        {

            //return (Next == null); // if next is null then return Note: () not necessary

            if (next == null)
            {
                return true;
            }
            else
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
