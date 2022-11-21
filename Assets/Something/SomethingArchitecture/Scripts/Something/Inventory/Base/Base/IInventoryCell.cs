using System;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base.Base
{
    public interface IInventoryCell
    {
        bool IsEquiped { get; set; }
        bool IsEmptry { get; set; }
        bool IsFull { get; }
        int Capacity { get; }
        int Amount { get; }

        Type ItemType { get; }
        IInventoryItem Item { get; }

        bool AddItem(IInventoryItem item, int count);
        void Clear();
    }
}