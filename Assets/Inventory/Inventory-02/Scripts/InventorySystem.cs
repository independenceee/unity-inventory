using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventorySystem
{
    public int InventorySize => InventorySlots.Count;
    [SerializeField] private List<InventorySlot> inventorySlots;
    public List<InventorySlot> InventorySlots => inventorySlots;
    public UnityAction<InventorySlot> OnInventorySlotChanged;
    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int index = 0; index < size; index++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlot> inventorySlot))
        {
            foreach (var slot in inventorySlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }

        }
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> inventorySlot)
    {
        inventorySlot = InventorySlots.Where(
            inventorySlot => inventorySlot.ItemData == itemToAdd
        ).ToList();
        InventorySlots.First(slot => slot.ItemData.MaxStackSize > 5);
        return inventorySlot == null ? false : true;
    }
    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot != null;
    }
}