using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] taulukko = new int[20];
            for (int i=0; i<taulukko.Length; i++)
            {
                taulukko[i] = rand.Next(50);
            }
            Heap heap = new Heap();
            System.Console.WriteLine("" + string.Join(",", heap.HeapSort(taulukko)));
            System.Console.ReadLine();

        }
    }
    class Heap
    {
        private List<HeapKnot> heap = new List<HeapKnot>();
        private HeapKnot head;

        public Heap()
        {
            head = new HeapKnot(0, 0);
            heap.Add(head);
            
        }

        public int[] HeapSort(int[] taulukko)
        {
            for (int i = 1; i < taulukko.Length; i++)
            {
                Add(taulukko[i]);
            }
            return SortedList();
        }

        private int[] SortedList()
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < head.data; i++)
            {
                lista.Add(removeSmallest());
            }

            return lista.ToArray();
        }

        private int removeSmallest()
        {
            HeapKnot last = heap[head.data];
            heap.RemoveAt(head.data);
            head.data--;
            int ret = heap[1].data;
            heap[1].data = last.data;
            AfterRemoveCheck(heap[1]);
            return ret;

        }

        private void AfterRemoveCheck(HeapKnot super)
        {
            int left = super.location*2;
            int right = left + 1;
            int helper = super.data;
            if (left > head.data) return;
            if (right > head.data || heap[left].data < heap[right].data)
            {
                if (heap[left].data < super.data)
                {
                    super.data = heap[left].data;
                    heap[left].data = helper;
                    AfterRemoveCheck(heap[left]);
                    return;
                }
            }
            else if (heap[left].data > heap[right].data)
            {
                if (heap[right].data < super.data)
                {
                    super.data = heap[right].data;
                    heap[right].data = helper;
                    AfterRemoveCheck(heap[right]);
                    return;
                }
            }
        }

        private void Add(int data)
        {
            head.data++;
            HeapKnot newKnot = new HeapKnot(data,head.data);
            HeapKnot last = newKnot;
            heap.Add(newKnot);
            if (head.data / 2 > 0)
            {
                HeapKnot super = heap[head.data / 2];
                checkPlacing(last, super);
            }
        }

        private void checkPlacing(HeapKnot last, HeapKnot super)
        {
            if (last.data < super.data)
            {
                int helper = super.data;
                super.data = last.data;
                last.data = helper;
                int lastLoc = super.location / 2;
                if (lastLoc> 0) {
                    checkPlacing(super, heap[lastLoc]);
                }
            }

        }
    }
    class HeapKnot
    {
        public int data;
        public int location;

        public HeapKnot(int data, int location)
        {
            this.data = data;
            this.location = location;
        }
    }
}
