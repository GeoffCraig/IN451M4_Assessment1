using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN451M4_Assessment1
{
    public class Customer
    {
        private int NumberOfItems;
        private int TimeWaited;
        private int TimeUsed;
        private DressingRooms dressingRooms;
        public Customer(DressingRooms dressingRooms, int NumberOfItems = 0)
        {
            this.dressingRooms = dressingRooms;
            if (NumberOfItems == 0)
            {
                this.NumberOfItems = new Random().Next(1, 7);
            }
            else
            {
                this.NumberOfItems = NumberOfItems;
            }
        }

        public void TryOnClothes()
        {

            DateTime Begin = DateTime.Now;
            Console.WriteLine("Requesting room");
            dressingRooms.RequestRoom();
            TimeWaited = (int)(DateTime.Now - Begin).TotalMilliseconds;
            for (int i = 0; i < this.NumberOfItems; i++)
            {
                int tryOn = new Random().Next(60000, 180000);
                Console.WriteLine($"Trying on clothes number {i + 1} of {this.NumberOfItems} for {TimeSpan.FromMilliseconds(tryOn)} minutes");
                ; Thread.Sleep(tryOn);
                Console.WriteLine($"Finished number {i + 1} of {this.NumberOfItems}");
                TimeUsed += tryOn;
            }
            dressingRooms.FinishedRoom();
        }
        public int GetTimeWaited()
        {
            return TimeWaited;
        }
        public int GetTimeUsed()
        {
            return TimeUsed;
        }
        public int GetNumberOfItems()
        {
            return NumberOfItems;
        }
    }
}
