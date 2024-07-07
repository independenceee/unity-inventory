using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Lesson 03/Items/Default")]
public class DefaultObject : ItemObject
{
    private void Awake()
    {
        itemType = ItemType.Default;
    }
}
