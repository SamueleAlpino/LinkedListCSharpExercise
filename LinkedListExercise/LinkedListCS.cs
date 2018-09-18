using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExercise
{
    public class LinkedListCS<T>
    {
        public LinkedListNodeCS<T> First { get; private set; }
        public LinkedListNodeCS<T> Last { get; private set; }
      
        //Maybe ULong
        public uint Count { get; private set; }

        private LinkedListNodeCS<T>[] allNodes = new LinkedListNodeCS<T>[256];

        public LinkedListNodeCS<T>[] GetNodes()
        {
            LinkedListNodeCS<T>[] toReturn = new LinkedListNodeCS<T>[Count];
            for (int i = 0; i < Count; i++)
            {
                if (allNodes[i] != null)
                    toReturn[i] = allNodes[i];
            }

            return toReturn.Reverse().ToArray();
        }

        public LinkedListNodeCS<T> AddFirst(T toAdd)
        {
            if (Count == allNodes.Length)
                allNodes = Duplicate(allNodes);

            if (First == null)
            {
                First = new LinkedListNodeCS<T>();
                First.List = this;
                First.Value = toAdd;
                allNodes[0] = First;
            }
            else
            {
                LinkedListNodeCS<T> beforeFirst = new LinkedListNodeCS<T>()
                { Value = First.Value, Prev = First, List = this };

                if (First.Next != null)
                {
                    beforeFirst.Next = First.Next;
                    beforeFirst.Next.Prev = beforeFirst;
                }

                //Set First
                First.Value = toAdd;
                First.Next = beforeFirst;
                First.Prev = null;

                allNodes[Count] = First;
                allNodes[Count - 1] = beforeFirst;
            }

            Last = allNodes[0];

            Count++;
            return First;
        }

        //To fix
        public LinkedListNodeCS<T> AddLast(T toAdd)
        {
            if (Last == null)
            {
                Last = new LinkedListNodeCS<T>();
                Last.List = this;
                Last.Value = toAdd;
                allNodes[Count] = Last;
            }
            else
            {
                LinkedListNodeCS<T> prev = new LinkedListNodeCS<T>()
                { Value = allNodes[Count - 1].Value, Next = Last };

                if (Last.Prev != null)
                {
                    prev.Prev = Last.Prev;
                    prev.Prev.Next = prev;
                    prev.Next = Last;
                }
                //Set Last
                Last.Value = toAdd;
                Last.Next = null;
                Last.Prev = prev;


                allNodes[Count] = Last;
                allNodes[Count - 1] = prev;
            }

            if (First == null)
                First = Last;
            else
                First = allNodes[0];

            Count++;
            return Last;
        }

        public LinkedListNodeCS<T> AddAfter(LinkedListNodeCS<T> target, T value)
        {
            LinkedListNodeCS<T> toAdd = new LinkedListNodeCS<T> { Value = value, List = this };

            for (int i = 0; i < Count; i++)
            {
                if (allNodes[i] == target)
                {
                    toAdd.Prev = target;
                    toAdd.Next = target.Next;
                    target.Next = toAdd;
                    toAdd.Next.Prev = toAdd;
                }
            }
            allNodes[Count] = toAdd;
            Count++;
            return toAdd;
        }

        public LinkedListNodeCS<T> AddBefore(LinkedListNodeCS<T> target, T value)
        {
            LinkedListNodeCS<T> toAdd = new LinkedListNodeCS<T> { Value = value, List = this };

            for (int i = 0; i < Count; i++)
            {
                if (allNodes[i] == target)
                {
                    toAdd.Prev = target.Prev;
                    toAdd.Next = target;
                    target.Prev = toAdd;
                    toAdd.Prev.Next = toAdd;
                }
            }
            allNodes[Count] = toAdd;
            Count++;
            return toAdd;
        }

        public LinkedListNodeCS<T> Find(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (allNodes[i] == null)
                    return null;
                else if(allNodes[i].Value.Equals(value))
                    return allNodes[i];
            }

            return null;
        }

        public void RemoveFirst()
        {
            try
            {
                LinkedListNodeCS<T> temp = First.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (allNodes[i] == First)
                        allNodes[i] = null;
                }
                First = temp;

                Count--;
            }
            catch (Exception e)
            {
                e = new Exception("The list is Empty!");
                throw e;
            }
        }

        public void RemoveLast()
        {
            try
            {
                LinkedListNodeCS<T> temp = Last.Prev;
                for (int i = 0; i < Count; i++)
                {
                    if (allNodes[i] == Last)
                        Last = temp;

                    //allNodes[i] = null;
                }
                Count--;
            }
            catch (Exception e)
            {
                e = new Exception("The list is Empty!");
                throw e;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                allNodes[i] = null;
            }
            Count = 0;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (allNodes[i].Equals(value))
                    return true;
            }

            return false;
        }


        public void Remove(LinkedListNodeCS<T> toRemove)
        {
            for (int i = 0; i < Count; i++)
            {
                if (toRemove == First)
                {
                    RemoveFirst();
                }
                else if (toRemove == Last)
                {
                    RemoveLast();
                }
                else if (allNodes[i] == toRemove)
                {
                    allNodes[i].Prev.Next = toRemove.Next;
                    allNodes[i].Next.Prev = toRemove.Prev;
                    allNodes[i] = null;
                    Count--;
                }
            }
        }

        public void Remove(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (allNodes[i].Value.Equals(value))
                {
                    LinkedListNodeCS<T> replacement = new LinkedListNodeCS<T>() { Next = allNodes[i].Next, Prev = allNodes[i].Prev };
                    allNodes[i] = replacement;
                    Count--;
                    break;
                }
            }
        }

        private LinkedListNodeCS<T>[] Duplicate(LinkedListNodeCS<T>[] toDuplicate)
        {
            LinkedListNodeCS<T>[] newArray = new LinkedListNodeCS<T>[toDuplicate.Length * 2];
           // ArrayList array = new ArrayList();

            for (int i = 0; i < toDuplicate.Length; i++)
            {
                newArray[i] = toDuplicate[i];
            }

            return newArray;
        }

    }
}

