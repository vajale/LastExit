using System;
using System.Collections.Generic;
using System.Linq;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base.Base;

public class Inventory : IInventory
{
    private List<IInventoryCell> _cells;

    public Inventory(int capacity)
    {
        _cells = new List<IInventoryCell>(capacity);
    }

    public int Capacity => _cells.Capacity;
    public bool IsFull => _cells.Capacity == _cells.Count(cell => cell.IsFull);


    public bool AddItem(IInventoryItem item, int count, object sender = null)
    {
        var slotWithSameItems = _cells.Find(cell => !cell.IsFull & cell.ItemType == item.Type);

        if (slotWithSameItems != null)
        {
            var check = slotWithSameItems.Amount + count <= slotWithSameItems.Capacity;
            var countToAdd = check ? count : (count - slotWithSameItems.Capacity) * -1;
            return slotWithSameItems.AddItem(item, countToAdd);
        }

        var freeSlot = _cells.Find(cell => cell.IsEmptry);

        if (freeSlot != null)
        {
            return freeSlot.AddItem(item, count);
        }
        
        return false;
    }

    public bool RemoveItem(Type itemType, int count, object sender = null)
    {
        return true;
    }

    public IInventoryItem GetItem(Type itemType, object sender = null)
    {
        var item = _cells.Find(cell => cell.ItemType == itemType).Item;
        return item;
    }


    public IInventoryItem[] GetItems(Type itemType, object sender = null)
    {
        var itemsOfType = new List<IInventoryItem>();
        var notEmptryCells = _cells.Where(cell => cell.IsEmptry == false);

        foreach (var cell in notEmptryCells)
            if (cell.ItemType == itemType)
                itemsOfType.Add(cell.Item);

        return itemsOfType.ToArray();
    }

    public IInventoryItem[] GetAllItems()
    {
        var notEmptryCells = _cells.Where(cell => cell.IsEmptry == false);
        var items = new List<IInventoryItem>();

        foreach (var cell in notEmptryCells)
            items.Add(cell.Item);

        return items.ToArray();
    }

    public IInventoryCell[] GetAllCells()
    {
        return _cells.ToArray();
    }
    
}