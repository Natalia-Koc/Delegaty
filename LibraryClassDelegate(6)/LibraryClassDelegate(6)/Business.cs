using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassDelegate_6_
{
    public delegate void DelegateWorker(Worker worker);
    public delegate string DelegateWorkerReturnString(Worker worker);
    public delegate bool DelegateWorkerReturnBool(Worker worker);
    public delegate int DelegateWorkerReturnInt(Worker worker, Worker worker1);
    public delegate IComparable DelegateWorkerReturnInt2(Worker worker);
    public delegate void DelegateAllWorkers<T>(T param);

    public class Business
    {

        public List<Worker> Workers { get; set; } = new List<Worker>();
        public event DelegateWorker OnAdded;
        public event DelegateWorker OnIncreasing;
        public event DelegateWorker OnIncreased;

        public void SortWorkers(DelegateWorkerReturnInt delegateWorkerReturnInt)
        {
            //sortowanie bąbelkowe 
            for (int i = 0; i < Workers.Count-1; i++)
            {
                for (int j = 0; j < Workers.Count-1; j++)
                {
                    if (delegateWorkerReturnInt.Invoke(Workers[j], Workers[j+1]) > 0)
                    {
                        Worker helpWorker = Workers[j];
                        Workers[j] = Workers[j+1];
                        Workers[j+1] = helpWorker;
                    }
                }
            }
        }

        public void SortWorkers2(DelegateWorkerReturnInt2 d)
        {
            //sortowanie bąbelkowe 
            for (int i = 0; i < Workers.Count - 1; i++)
            {
                for (int j = 0; j < Workers.Count - 1; j++)
                {
                    if (d(Workers[j]).CompareTo(d(Workers[j+1])) > 0)
                    {
                        Worker helpWorker = Workers[j];
                        Workers[j] = Workers[j + 1];
                        Workers[j + 1] = helpWorker;
                    }
                }
            }
        }
        public void Add( Worker worker)
        {
            Workers.Add(worker);
            OnAdded?.Invoke(worker);
        }
        public void IncreaseSalaries(int id, float rise)
        {
            foreach (var item in Workers)
            {
                if (item.Identifier.Equals(id))
                {
                    OnIncreasing?.Invoke(item);
                    item.Salary += rise;
                    OnIncreased?.Invoke(item);
                }
            }
        }
        public List<Worker> FindAllWorkersByParameter(DelegateWorkerReturnBool delegateWorkerReturnBool)
        {
            List<Worker> helpList = new List<Worker>();

            foreach (var item in Workers)
            {
                if (delegateWorkerReturnBool.Invoke(item))
                {
                    helpList.Add(item);
                }
            }
            return helpList;
        }
        public void DisplayAllWorkers(DelegateWorkerReturnString delegateWorker)
        {
            foreach (var item in Workers)
            {
                Console.WriteLine(delegateWorker.Invoke(item));
            }
        }
        public void DoForEveryone(DelegateWorker delegateWorker)
        {
            foreach (var item in Workers)
            {
                delegateWorker.Invoke(item);
            }
        }
        public Worker FindWorkerById(int id)
        {
            return Workers.Find(p => p.Identifier == id);
        }
        public List<Worker> FindAllWorkersByPhrase(string phrase)
        {
            return Workers.FindAll(p => p.Name.Contains(phrase) || p.Surname.Contains(phrase));
        }
        public List<Worker> FindAllWorkersByNumberSales(int minSales, int maxSales)
        {
            return Workers.FindAll(p => p.NumberOfSales > minSales && p.NumberOfSales < maxSales);
        }
    }
}
