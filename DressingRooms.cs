using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN451M4_Assessment1
{
    public class DressingRooms
    {
        private Semaphore semaphore;
        public int numberOfRooms { get; private set; }
        public DressingRooms(int numberOfRooms)
        {
            this.numberOfRooms = numberOfRooms;
            semaphore = new Semaphore(numberOfRooms, numberOfRooms);
        }

        public DressingRooms()
        {
            this.numberOfRooms = 3;
            semaphore = new Semaphore(numberOfRooms, numberOfRooms);
        }

        public void RequestRoom()
        {
            semaphore.WaitOne();
        }

        public void FinishedRoom()
        {
            semaphore.Release();
        }
    }
}
