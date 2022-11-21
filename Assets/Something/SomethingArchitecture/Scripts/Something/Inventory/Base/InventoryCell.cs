using System;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base.Base
{
    public class InventoryCell : IInventoryCell
    {
        public InventoryCell()
        {
        }

        public bool IsEquiped { get; set; }
        public bool IsEmptry { get; set; }
        public bool IsFull { get; }
        public int Capacity { get; }
        public int Amount { get; private set; }
        public Type ItemType { get; }
        public IInventoryItem Item { get; private set; }

        public bool AddItem(IInventoryItem item, int count)
        {
            if (IsEquiped == false)
            {
                SwitchItem(item);
            }

            if (Amount + count > Capacity & item.Type != ItemType)
                return false;

            Item = item;
            Amount += count;
            return true;
        }

        public void Clear()
        {
            Item = null;
            Amount = 0;
        }

        private void SwitchItem(IInventoryItem item)
        {
        }
    }
}