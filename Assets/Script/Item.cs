using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public int cri;

    public bool isEquip = false;

}



