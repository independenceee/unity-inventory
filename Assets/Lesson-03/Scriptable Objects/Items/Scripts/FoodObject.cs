using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Lesson 03/Items/Food")]
public class FoodObject : ItemObject
{
    public int restoreHealthValue;
    public void Awake()
    {
        itemType = ItemType.Food;
    }
}
