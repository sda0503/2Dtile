using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using static Item;

[System.Serializable]
public class SaveData
{
    public List<string> stringData = new List<string>();
    public List<int> intData = new List<int>();
    public List<Item> inventoryData = new List<Item>();
    public List<int> itemInum =  new List<int> ();
    public List<int> itemPower = new List<int>();
    public List<Item.ItemType> itemtype = new List<Item.ItemType>();
    public List<bool> itemEquip = new List<bool>();
    public List<string> itemName = new List<string>();
    public List<UserData> userDatas = new List<UserData>();

}

public class Json : MonoBehaviour
{

    public GameObject player;
    Rabbit rabbit;

    string path;

    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
    }

    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        //JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();
        string loadJson = File.ReadAllText(path);
        saveData = JsonUtility.FromJson<SaveData>(loadJson);
        Debug.Log(saveData.inventoryData.Count);

        if (saveData != null)
        {
            for (int i = 0; i < saveData.stringData.Count; i++)
            {
                rabbit.datas[i]  = saveData.stringData[i];
            }
            rabbit.lv = saveData.intData[0];
            rabbit.exp = saveData.intData[1];
            rabbit.maxExp = saveData.intData[2];
            rabbit.money = saveData.intData[3];
            rabbit.bankMoney = saveData.intData[4];
            rabbit.maxInventory = saveData.intData[5];


            rabbit.inventory.Clear();
            for (int i = 0; i < saveData.inventoryData.Count; i++)
            {
                saveData.inventoryData[i].iNum = saveData.itemInum[i]; 
                saveData.inventoryData[i].power = saveData.itemPower[i];
                saveData.inventoryData[i].type = saveData.itemtype[i];
                saveData.inventoryData[i].isEquip = saveData.itemEquip[i];
                saveData.inventoryData[i].itemName = saveData.itemName[i];
                rabbit.inventory.Add(saveData.inventoryData[i]);
            }
            InfoManager.instance.CheckStatus();
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i < rabbit.datas.Length; i++)
        {
            saveData.stringData.Add(rabbit.datas[i]);
        }
        saveData.intData.Add(rabbit.lv);
        saveData.intData.Add(rabbit.exp);
        saveData.intData.Add(rabbit.maxExp);
        saveData.intData.Add(rabbit.money);
        saveData.intData.Add(rabbit.bankMoney);
        saveData.intData.Add(rabbit.maxInventory);

        for (int i = 0; i < rabbit.inventory.Count; i++)
        {
            saveData.inventoryData.Add(rabbit.inventory[i]);
            saveData.itemInum.Add(rabbit.inventory[i].iNum);
            saveData.itemPower.Add(rabbit.inventory[i].power);
            saveData.itemtype.Add(rabbit.inventory[i].type);
            saveData.itemEquip.Add(rabbit.inventory[i].isEquip);
            saveData.itemName.Add(rabbit.inventory[i].itemName);
        }

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
        Debug.Log("데이터 저장");
    }
}
