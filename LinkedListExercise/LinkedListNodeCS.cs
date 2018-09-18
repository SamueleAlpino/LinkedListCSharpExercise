using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExercise
{
    public class LinkedListNodeCS<T>
    {
        public LinkedListCS<T> List { get; internal set; }

        public LinkedListNodeCS<T> Next { get; set; }
        public LinkedListNodeCS<T> Prev { get; set; }
        public T Value { get; set; }

        internal LinkedListNodeCS<T> Clone()
        {
            return MemberwiseClone() as LinkedListNodeCS<T>;
        }
    }
}
