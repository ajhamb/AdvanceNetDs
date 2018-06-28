using System;
using System.Collections;
using System.Collections.Generic;

namespace AdvanceNetDs.Shared
{
    public class Node<T> where T: IComparable<T>
    {
        public T Data { get; set; }
    }
}
