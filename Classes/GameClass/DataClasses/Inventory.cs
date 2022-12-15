using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRPG.Classes.GameClass.DataClasses
{
    class Inventory<T>
    {
        private List<T> inventory;
        public int InventorySize;
        public Inventory(T empty, int size)
        {
            InventorySize = size;
            inventory = new List<T>();
            for (int i = 0; i < size; i++)
            {
                inventory.Add(empty);
            }
        }
        public T[] GetAll() { return inventory.ToArray(); }
        public void Put(T str) { inventory.Add(str); }
    }
}
