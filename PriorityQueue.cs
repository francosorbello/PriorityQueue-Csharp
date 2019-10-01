using System.Collections;
using System.Collections.Generic;

namespace MyPriorityQueue
{
    public class PriorityQueue<T> : IEnumerable<T>
    {
        private List<T> data;
        private List<int> priorities;

        public int Count{ get {return data.Count;} }

        public PriorityQueue()
        {
            this.data = new List<T>();
            this.priorities = new List<int>();
        }

        public void Enqueue(T item, int priority)
        {
            if (this.data.Count == 0)
            {
                this.data.Add(item);
                this.priorities.Add(priority);
                return;
            }

            int i = 0;
            foreach (var pri in this.priorities)
            {
                if (pri > priority)
                {
                    break;
                }
                i+=1;
            }
            this.data.Insert(i,item);
            this.priorities.Insert(i,priority);
        }

        public T Dequeue()
        {
            var node = this.data[0];
            this.data.RemoveAt(0);
            this.priorities.RemoveAt(0);
            return node;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }    
        
    }
}
