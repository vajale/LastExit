using System;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base.Base
{
    public interface IInventory
    {
        public int Capacity { get; }
        bool IsFull { get; }

        public bool AddItem(IInventoryItem item, int count, object sender = null);
        public bool RemoveItem(Type itemType, int count, object sender = null);

        public IInventoryItem GetItem(Type itemType, object sender = null);
        public IInventoryItem[] GetItems(Type itemType, object sender = null);

        public IInventoryCell[] GetAllCells();
        public IInventoryItem[] GetAllItems();
    }
}