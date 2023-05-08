using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace L1_A
{
    class Program
    {
        const string cfd = "Students_textfile.txt";
        static readonly object _lock = new object();
        static void Main(string[] args)
        {
            DataMonitor students = new DataMonitor();
            SortedResultMonitor s = new SortedResultMonitor(); 
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 6; i++)
            {
                var thread = new Thread(
                () => Worker(students, s));
                threads.Add(thread);
            }

            foreach (var item in threads) { item.Start(); }
            Read(cfd, students);
            s.Printtxt();
            s.Print();
            foreach (var item in threads) { item.Join(); }

        }
        static void Read(string fv, DataMonitor studs)
        {
            string name, line;
            int year, n;
            double grade;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = File.ReadAllLines(fv).Count();                
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(',');
                    name = parts[0];
                    year = int.Parse(parts[1]);
                    grade = double.Parse(parts[2]);
                    Student s = new Student(name, year, grade);
                    studs.AddItem(s);
                }
            }
        }

        static void Worker(DataMonitor studs, SortedResultMonitor s)
        {
            try
            {
                while (true)
                {
                    var stud = studs.RemoveItem();
                    if (stud == null)
                    {
                        break;
                    }
                    s.AddItemSorted(stud);
                }
            }
            finally
            {
                Monitor.Exit(_lock);    
            }
        }

    }
}

    


