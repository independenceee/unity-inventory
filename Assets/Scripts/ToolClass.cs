using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{

    [Header("Tool")]
    public ToolType toolType;
    public enum ToolType
    {
        weapon,
        pickaxe,
        hammer,
        axe
    }
    public override ConsumableClass GetConsumable()
    {
        return null;
    }

    public override ItemClass GetItem()
    {
        return this;
    }

    public override MiscClass GetMisc()
    {
        return null;
    }

    public override ToolClass GetTool()
    {
        return this;
    }
}
