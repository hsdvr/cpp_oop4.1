using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OOPLab4
{
    //internal class Storage
    //{
    //    Figure[] elements;
    //    public int size { get; set; }

    //    public Storage()
    //    {
    //        size = 0;
    //    }

    //    public void push_back(in Figure element)
    //    {
    //        Figure[] changedElements = new Figure[size + 1];
    //        int i = 0;
    //        for (; i < size; i++)
    //        {
    //            changedElements[i] = elements[i];
    //        }
    //        changedElements[i] = element;
    //        elements = changedElements;
    //        ++size;
    //    }

    //    public void push_front(in Figure element)
    //    {
    //        Figure[] changedElements = new Figure[size + 1];
    //        changedElements[0] = element;
    //        for (int i = 1; i < changedElements.Length; i++)
    //        {
    //            changedElements[i] = elements[i];
    //        }
    //        elements = changedElements;
    //        ++size;
    //    }

    //    public ref Figure pop(int index)
    //    {
    //        ref Figure result1 = ref elements[0];
    //        if (size == 1)
    //        {
    //            elements = null;
    //            --size;
    //            return ref result1;
    //        }
    //        Figure[] changedElements = new Figure[size - 1];
    //        for (int i = 0; i < index; ++i)
    //        {
    //            changedElements[i] = elements[i];
    //        }
    //        ref Figure result2 = ref elements[index];
    //        for (int i = index + 1; i < size; ++i)
    //        {
    //            changedElements[i - 1] = elements[i];
    //        }
    //        elements = changedElements;
    //        --size;
    //        return ref result2;
    //    }

    //    public ref Figure getObject(int index)
    //    {
    //        return ref elements[index];
    //    }

    //    public void deleteActiveElements()
    //    {
    //        for (int i = 0; i < size; i++)
    //        {
    //            if (elements[i].isActive)
    //            {
    //                pop(i);
    //                --i;
    //            }
    //        }
    //    }
    //}

 

    public class Storage : IEnumerable
    {
        public class Node
        {
            public Figure Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(Figure data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
            public bool IsActive()
            {
                return this.Data.isActive;
            }
        }
        private Node head;
        private Node tail;
        private int count;

        public int size
        {
            get { return count; }
        }

        public void push_front(Figure data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

            count++;
        }

        public void push_back(Figure data)
        {
            Node newNode = new Node(data);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        public bool remove(Figure data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Prev == null)
                    {
                        head = current.Next;
                        if (head != null)
                            head.Prev = null;
                        else
                            tail = null;
                    }
                    else if (current.Next == null)
                    {
                        tail = current.Prev;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool contains(Figure data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public Figure get_front()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");

            return head.Data;
        }

        public Figure get_back()
        {
            if (tail == null)
                throw new InvalidOperationException("List is empty");

            return tail.Data;
        }

        public IEnumerator<Figure> get_enumerator()
        {
            Node current = tail;

            while (current != null)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }
        public IEnumerator<Figure> get_enumerator_rev()
        {
            
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return get_enumerator();
        }
        
        IEnumerator GetEnumeratorReverse()
        {
            return get_enumerator_rev();
        }

        //public void deleteActiveElements()
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        if (IEnumerator<T> enumer = this.get_enumerator())
        //        {
        //            pop(i);
        //            --i;
        //        }
        //    }
        //}

        public void deleteActiveElements()
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.isActive)
                {
                    if (current.Prev == null)
                    {
                        head = current.Next;
                        if (head != null)
                            head.Prev = null;
                        else
                            tail = null;
                    }
                    else if (current.Next == null)
                    {
                        tail = current.Prev;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    count--;
                    
                }

                current = current.Next;
            }

            
        }
    }

}
