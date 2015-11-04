using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;
        private int count;

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)//params 1 type of the same array.  Treat the arguements themselves as part of an array.
        {
            count = 0;
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i].ToString());
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
       public string this[int i]
        {
            get { return ElementAt(i); }
            set
            {
                NodeAt(i).Value = value;
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            if (ElementAt(-1) == existingValue)
            {
                AddLast(value);
            }
            else
            {

                SinglyLinkedListNode current = firstNode;
                bool found = false;
                while (!current.IsLast())
                {
                    if (current.Value == existingValue)
                    {
                        SinglyLinkedListNode new_node = new SinglyLinkedListNode(value);
                        SinglyLinkedListNode old_next = current.Next;
                        new_node.Next = old_next;
                        current.Next = new_node;

                        found = true;
                        count++;
                        break;
                    }
                    current = current.Next;
                }

                if (!found)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void AddFirst(string value)
        {
            
            if (firstNode == null)
            {
                AddLast(value);
            }
            else
            {
                SinglyLinkedListNode item = firstNode;
                firstNode = new SinglyLinkedListNode(value);
                firstNode.Next = item;
                count++;
            }
        }

        public void AddLast(string value)
        {
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {
                SinglyLinkedListNode currentNode = firstNode;
                while (!currentNode.IsLast())
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new SinglyLinkedListNode(value);
            }
            count++; 
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return count;
        }
        private SinglyLinkedListNode NodeAt(int index)
        {
            if (firstNode != null && index >= 0)
            {
                SinglyLinkedListNode node = firstNode;
                for (int i = 0; i <= index; i++)
                {
                    if (index == i)
                    {
                        break;
                    }
                    if (node.Next == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    node = node.Next;
                }
                return node;
            }
            else if (index < 0)
            {
                return this.NodeAt(Count() + index); //Positive index/offset
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string ElementAt(int index)
        {
            return NodeAt(index).Value;        
        }

        public string First()
        {
            if (null == firstNode) //null first will help if you have trouble with remembering ==
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public int IndexOf(string value)
        {
            int position = 0; //assume it will not be found
            SinglyLinkedListNode current_node = firstNode;
            bool found = false;
            if (firstNode == null)
            {
                position = -1;
            } else
            {
                //position++;
                while (current_node != null)
                {
                    if (value == current_node.Value)
                    {
                        found = true;
                        break;
                    }
                    current_node = current_node.Next;
                    position++;
                }
                if (!found)
                {
                    position = -1;
                }
            }
            return position;
        }

        public bool IsSorted()
        {
            if (Count() == 0)
            {
                return true;
            }
            SinglyLinkedListNode left = firstNode;
            SinglyLinkedListNode right = firstNode.Next;

            while (right != null)
            {
                if (left > right)
                {
                    return false;
                }

                left = right;
                right = left.Next;
            }
            return true;
            
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (firstNode == null)
            {
                return null;
            } else {
                return this.ElementAt(-1);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (firstNode != null)
            {
                SinglyLinkedListNode nodes = firstNode;
                while (!nodes.IsLast())
                {
                    sb.Append("\"");
                    sb.Append(nodes.Value.ToString());
                    sb.Append("\"");
                    sb.Append(", ");
                    nodes = nodes.Next;
                }
                sb.Append("\"" + nodes.Value.ToString() + "\" ");
            }

            return "{ " + sb + "}";
        }

        public void Remove(string value)
        {
            int position = IndexOf(value);
            if (position >= 0)
            {
                if (position == 0)
                {
                    firstNode = firstNode.Next;
                }
                else if (position >= 1 && !NodeAt(position).IsLast())
                {
                    NodeAt(position - 1).Next = NodeAt(position + 1);
                }
                else if (NodeAt(position).IsLast())
                {
                    NodeAt(position - 1).Next = null;
                }
                count--;
            }
        }
    
        public void Sort()
        {
            if (Count() == 0)
            {
                return;
            } 
            SinglyLinkedListNode left = firstNode;
            SinglyLinkedListNode right = firstNode.Next;
            bool swapOccurred = false;
            while (right != null)
            {
                if (left > right)
                {
                    //they need to be swapped!
                    string value = left.Value;
                    left.Value = right.Value;
                    right.Value = value;
                    swapOccurred = true;
                }
                left = right;
                right = left.Next;
            }
            if (swapOccurred)
            {
                Sort();
            }
        }        

        public string[] ToArray()
        {
            SinglyLinkedListNode node = firstNode;
            if (node != null)
            {
                string[] answer = new string[Count()];
                for (int i = 0; i < Count(); i++)
                {
                    answer[i] = ElementAt(i);
                }
                return answer;
            }
            else
            {
                return new string[] { };
            }
        }
    }
}
  

