using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Mics")]
public class MiscClass : ItemClass
{
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
        return this;
    }

    public override ToolClass GetTool()
    {
        return null;
    }
}
