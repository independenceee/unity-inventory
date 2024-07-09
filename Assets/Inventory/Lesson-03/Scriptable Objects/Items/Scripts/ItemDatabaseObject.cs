using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "Lesson 03/Item/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        for (int index = 0; index < Items.Length; index++)
        {
            GetId.Add(Items[index], index);
            GetItem.Add(index, Items[index]);
        }
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }
}
