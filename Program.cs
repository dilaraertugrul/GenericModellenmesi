using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericModellenmesi
{
    public class Dugum<T>
    {
        public T veri { get; set; }
        public Dugum<T> ileri { get; set; }

        public Dugum(T veri)
        {
            this.veri = veri;
            ileri = null;
        }
    }
    public class Stack<T>
    {
        private Dugum<T> top;

        public Stack()
        {
            top = null;
        }

        public void Push(T veri)
        {
            Dugum<T> newNode = new Dugum<T>(veri);
            newNode.ileri = top;
            top = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack boş!");

            T data = top.veri;
            top = top.ileri;
            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack boş");
            return top.veri;
        }
        public bool IsEmpty()
        {
            return top == null;
        }
        public void Yazdir()
        {
            Console.WriteLine("Stack içi: ");
            Dugum<T> simdi = top;
            while (simdi != null)
            {
                Console.WriteLine(simdi.veri);
                simdi = simdi.ileri;
            }
            Console.WriteLine();
        }
    }
    public class Queue<T>
    {
        private Dugum<T> on;
        private Dugum<T> arka;

        public Queue()
        {
            on = arka = null;
        }

        public void Enqueue(T veri)
        {
            Dugum<T> newNode = new Dugum<T>(veri);
            if (arka == null)
            {
                on = arka = newNode;
                return;
            }

            arka.ileri = newNode;
            arka = newNode;
        }
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue boş!");

            T data = on.veri;
            on = on.ileri;

            if (on == null)
                arka = null;

            return data;
        }
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue boş!");
            return on.veri;
        }

        public bool IsEmpty()
        {
            return on == null;
        }
        public void yazdir()
        {
            Console.WriteLine("Queue içeriği (önden arkaya):");
            Dugum<T> simdi = on;
            while (simdi != null)
            {
                Console.WriteLine(simdi.veri);
                simdi = simdi.ileri;
            }
            Console.WriteLine();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" STACK İÇİN");
            Stack<string> stack = new Stack<string>();
            stack.Push("Elma");
            stack.Push("Armut");
            stack.Push("Kiraz");
            stack.Yazdir();  // Kiraz Armut  Elma

            Console.WriteLine("Pop: " + stack.Pop()); // Kiraz
            stack.Yazdir();

            Console.WriteLine("Peek: " + stack.Peek()); // Armut
            Console.WriteLine();

            Console.WriteLine("🔸 QUEUE TESTİ 🔸");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.yazdir(); // 10 -> 20 -> 30

            Console.WriteLine("Dequeue: " + queue.Dequeue()); // 10
            queue.yazdir();

            Console.WriteLine("Peek: " + queue.Peek()); // 20
        }
    }
}
