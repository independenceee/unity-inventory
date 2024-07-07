using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int quantity;

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }


    public SlotClass(ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem()
    {
        return item;
    }

    public int GetQuantity()
    {
        return quantity;
    }
    public void AddQuantiry(int _quantity)
    {
        quantity += _quantity;
    }

    public void SubQuantity(int _quantity)
    {
        quantity -= _quantity;
    }

    public void AddItem(ItemClass item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
