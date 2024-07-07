using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;
    public List<SlotClass> items = new List<SlotClass>();
    private GameObject[] slots;
    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        // set all the slots
        for (int index = 0; index < slotHolder.transform.childCount; index++)
        {
            slots[index] = slotHolder.transform.GetChild(index).gameObject;
        }

        RefreshUI();

    }

    public void RefreshUI()
    {
        for (int index = 0; index < slots.Length; index++)
        {
            try
            {
                slots[index].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[index].transform.GetChild(0).GetComponent<Image>().sprite = items[index].GetItem().itemIcon;
                Debug.Log(slots[index].transform.GetChild(1).GetComponent<Text>());
                if (items[index].GetItem().isStackable)
                {
                    slots[index].transform.GetChild(1).GetComponent<Text>().text = items[index].GetQuantity().ToString();
                }
                else
                {
                    slots[index].transform.GetChild(1).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                slots[index].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[index].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[index].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }

    public bool Add(ItemClass item)
    {
        // items.Add(item);

        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantiry(1);
        }
        else
        {
            if (items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, 1));
            }
            else
            {
                return false;
            }
        }
        RefreshUI();

        return true;
    }
    public bool Remove(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                SlotClass slotToRemove = new SlotClass();
                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                items.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }


        RefreshUI();
        return true;

    }

    public SlotClass Contains(ItemClass item)
    {

        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                return slot;
            }
        }
        return null;
    }
}
