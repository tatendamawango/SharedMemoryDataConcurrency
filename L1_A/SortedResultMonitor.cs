using System;
using System.IO;

namespace L1_A
{
    class SortedResultMonitor
    {
        const int arrSize = 25;
        private readonly Student[] Students;
        private int n;
        const string cfr = @"C:\Users\tmawa\source\repos\Lab1_A\L1_A\L1_AResults.txt";
        public SortedResultMonitor()
        {
            n = 0;
            Students = new Student[arrSize];
        }

        public Student Get(int i) { return Students[i]; }
        public void AddItemSorted(Student item)
        {
            if (!char.IsDigit(item.Hash[0]))
            {
                Students[n++] = item;
                Sort();
            }
        }

        public int Count() { return n; }

        public Student GetItems()
        {
            return Students[n];
        }

        public void Sort()
        {
            var flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < Count() - 1; i++)
                {
                    var a = Students[i];
                    var b = Students[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        Students[i] = b;
                        Students[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Results");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(" Name    \t|    Year |   Grade | Hash\t\t\t     |");
            Console.WriteLine(new string('-', 70));
            for (int i = 0; i < n; i++)
            {
                var student = Get(i);
                if (student != null)
                    Console.WriteLine("{0} {1} |",student.ToString() , student.Hash);
            }
            Console.WriteLine(new string('-', 70));
            Console.WriteLine();
        }

        public void Printtxt()
        {
            if (File.Exists(cfr))
                File.Delete(cfr);

            using (StreamWriter fr = new StreamWriter(cfr, true))
            {
                fr.WriteLine("Results");
                fr.WriteLine(new string('-', 70));
                fr.WriteLine(" Name           |    Year |   Grade | Hash\t\t\t         |");
                fr.WriteLine(new string('-', 70));
                for (int i = 0; i < n; i++)
                {
                    var student = Get(i);
                    if (student != null)
                        fr.WriteLine("{0} {1} |", student.ToString(), student.Hash);
                }
                fr.WriteLine(new string('-', 70));
            }
        }
        
    }

}
