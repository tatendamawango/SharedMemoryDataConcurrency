using System;
using System.Linq;
using System.Threading;

namespace L1_A
{
    class DataMonitor
    {
        static readonly object _lock = new object();
        const int arrSize = 10;
        private readonly Student[] Students;
        private int N { get; set; }
        public DataMonitor()
        {
            N = 0;
            Students = new Student[arrSize];
        }

        public void AddItem(Student item)
        {
            lock (_lock)
            {
                while (N >= arrSize)
                {
                    Monitor.Wait(_lock);
                }
                Students[N++] = item;
                Monitor.PulseAll(_lock);
            }
        
        }

        public int Count() { return N; }

        public Student Get(int i) { return Students[i]; }
        public Student RemoveItem()
        {
            lock (_lock)
            {

                while (N == 0)
                {
                    Monitor.Wait(_lock);
                }

                Student d = null;
                if (Students[0] != null)
                {
                    d = Students[0];
                    for (int i = 0; i < N - 1; i++)
                    {
                        Students[i] = Students[i + 1];
                    }
                    Students[arrSize - 1] = null;
                    N--;
                    Monitor.PulseAll(_lock);
                    return d;
                }
                N--;
                Monitor.PulseAll(_lock);
                return d;
            }
            
        }
        
        public void Print(string text = "")
        {
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 37));
            Console.WriteLine(" Name    \t|    Year |   Grade |");
            Console.WriteLine(new string('-', 37));
            for (int i = 0; i < Students.Count(); i++)
            {
                var student = Get(i);
                if (student != null)
                    Console.WriteLine(student.ToString());
            }
            Console.WriteLine(new string('-', 37));
            Console.WriteLine();
        }

    }
}
