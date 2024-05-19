using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN451M4_Assessment1
{
    public class Scenario
    {
        private DressingRooms dressingRooms;
        private List<Customer> customerThreads;
        private DateTime TimeStarted;
        private DateTime TimeCompleted;

        public Scenario(int rooms, int customers)
        {
            dressingRooms = new DressingRooms(rooms);
            customerThreads = new List<Customer>();
            for (int i = 0; i < customers; i++)
            {
                customerThreads.Add(new Customer(dressingRooms));
            }
        }

        public void Run()
        {
            TimeStarted = DateTime.Now;
            //Going to do a Parallel.ForEach instead of looping through threads
            Parallel.ForEach(customerThreads, (customer) =>
            {
                customer.TryOnClothes();
            });
            TimeCompleted = DateTime.Now;
        }
        public void OutputResults()
        {
            int totalWaitTime = 0;
            int totalUsedTime = 0;
            int totalItems = 0;

            foreach (var customer in customerThreads)
            {
                totalWaitTime += customer.GetTimeWaited();
                totalUsedTime += customer.GetTimeUsed();
                totalItems += customer.GetNumberOfItems();
            }

            int elapsedTime = (int)(TimeCompleted - TimeStarted).TotalMilliseconds;
            TimeSpan timeSpanElapsedTime = TimeSpan.FromMilliseconds(elapsedTime);
            double averageWaitTime = (double)totalWaitTime / customerThreads.Count;
            TimeSpan timeSpanAverageWaitTime = TimeSpan.FromMilliseconds(averageWaitTime);
            double averageUsageTime = (double)totalUsedTime / customerThreads.Count;
            TimeSpan timeSpanAverageUsageTime = TimeSpan.FromMilliseconds(averageUsageTime);
            double averageItems = (double)totalItems / customerThreads.Count;

            Console.WriteLine($"Number of rooms: {dressingRooms.numberOfRooms}");
            Console.WriteLine($"Number of customers: {customerThreads.Count}");
            Console.WriteLine($"Elapsed time: {timeSpanElapsedTime} minutes");
            Console.WriteLine($"Average wait time: {timeSpanAverageWaitTime} minutes");
            Console.WriteLine($"Average usage time: {timeSpanAverageUsageTime} minutes");
            Console.WriteLine($"Average number of items: {averageItems}");
        }
    }
}
