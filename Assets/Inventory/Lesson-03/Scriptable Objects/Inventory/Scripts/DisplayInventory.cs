using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int xStart;
    public int yStart;
    public int numberOfColumn;
    public int xSpaceBetweenItem;
    public int ySpaceBetweenItem;

    Dictionary<InventorySlots, GameObject> itemsDisplayed = new Dictionary<InventorySlots, GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int index = 0; index < inventory.Container.Count; index++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[index]))
            {
                itemsDisplayed[inventory.Container[index]].GetComponentInChildren<Text>().text = inventory.Container[index].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[index].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(index);
                obj.GetComponentInChildren<Text>().text = inventory.Container[index].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[index], obj);
            }
        }
    }


    public void CreateDisplay()
    {
        for (int index = 0; index < inventory.Container.Count; index++)
        {
            var obj = Instantiate(inventory.Container[index].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(index);
            obj.GetComponentInChildren<Text>().text = inventory.Container[index].amount.ToString("n0");
        }
    }

    public Vector3 GetPosition(int index)
    {
        return new Vector3(xStart + xSpaceBetweenItem * (index % numberOfColumn), yStart - ySpaceBetweenItem * (index / numberOfColumn), 0f);
    }
}
