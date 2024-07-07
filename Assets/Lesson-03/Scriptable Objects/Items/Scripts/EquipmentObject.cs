using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Lesson 03/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float atkBonus;
    public float defenceBonus;

    public void Awake()
    {

    }
}
