using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Lesson 03/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public List<InventorySlots> Container = new List<InventorySlots>();

    private void OnEnable()
    {
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Scriptale Objects/Item.Database.asset", typeof(ItemDatabaseObject));
        database = Resources.Load<ItemDatabaseObject>("Database");
    }

    public void AddItem(ItemObject _item, int _amount)
    {
        for (int index = 0; index < Container.Count; index++)
        {
            if (Container[index].item == _item)
            {
                Container[index].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlots(database.GetId[_item], _item, _amount));
    }
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));

        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(binaryFormatter.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public void OnAfterDeserialize()
    {
        for (int index = 0; index < Container.Count; index++)
        {
            Container[index].item = database.GetItem[Container[index].ID];
        }
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}

[Serializable]
public class InventorySlots
{
    public int ID;
    public ItemObject item;
    public int amount;
    public InventorySlots(int _id, ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}