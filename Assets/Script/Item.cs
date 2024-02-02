using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public enum ItemType { NONE, WEAPON, ARMORBODY, ARMORHEAD, ARMORHAND, ARMORFOOT, ACCESSORY, USE };


    public Sprite[] itemImages;

    public int iNum;
    public string itemName;
    public string desc;
    public int gold;
    public ItemType type = ItemType.NONE;
    public int power;
    public int atk;
    public int def;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Image>().sprite = itemImages[iNum];
    }

    public void SetPow()
    {
        switch(type)
        {
            case ItemType.WEAPON: atk = power; break;
            case ItemType.ARMORBODY: def = power; break;
            case ItemType.ARMORHEAD: def = power; break;
            case ItemType.ARMORHAND: atk = power; break;
            case ItemType.ARMORFOOT: def = power; break;
            case ItemType.ACCESSORY: hp = power; break;
        }
    }


}

