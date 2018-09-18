using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListCS<string> list = new LinkedListCS<string>();

            string write = " 1. Add First\n 2. Add Last\n 3. Remove First\n 4. Remove Last\n 5. Show number of items\n 6. Show all items\n 7. Exit ";
            Console.WriteLine("Linked list operations Menu\n==============================");
            Console.WriteLine(write);

            LinkedListCS<int> linkedList = new LinkedListCS<int>();
            for (int i = 0; i < 4; i++)
                linkedList.AddLast(i);

            linkedList.Remove(linkedList.Find(2));
            linkedList.Find(2);
            while (true)
            {
                Console.WriteLine("==============================\n Press \"m\" for show the menu\n==============================");
                //Debug
                if (list.First != null)
                    Console.WriteLine("First :" + list.First.Value);
                if (list.Last != null)
                    Console.WriteLine("Last  :" + list.Last.Value);

                string readLine = Console.ReadLine();
                Console.Clear();
                char toCheck = readLine.ToCharArray()[0];
                if (toCheck == '1')
                {
                    Console.WriteLine("Add First :");
                    list.AddFirst(Console.ReadLine());
                    Console.WriteLine("First Element added!");
                }
                else if (toCheck == '2')
                {
                    Console.WriteLine("Add Last :");
                    list.AddLast(Console.ReadLine());
                    Console.WriteLine("Last Element added!");
                }
                else if (toCheck == '3')
                {
                    list.RemoveFirst();
                    Console.WriteLine("First element removed");
                }
                else if (toCheck == '4')
                {
                    list.RemoveLast();
                    Console.WriteLine("Last element removed");
                }
                else if (toCheck == '5')
                {
                    Console.WriteLine(list.Count);
                }
                else if (toCheck == '6')
                {
                    foreach (LinkedListNodeCS<string> item in list.GetNodes())
                    {
                        if (item != null)
                            Console.WriteLine(item.Value);
                    }
                }
                else if (toCheck == '7')
                {
                    break;
                }
                else if (toCheck == 'm')
                {
                    Console.WriteLine(write);
                }
            }
        }
    }
    
}
