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

    public bool isEquip = false;

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

    public void OnEquip()
    {
        if(isEquip)
        {
            isEquip = false;
            PopupEquipClear();
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            isEquip = true;
            PopupEquip();
            transform.GetChild(1).gameObject.SetActive(true);

        }
    }

    void PopupEquip()
    {
        GameObject popup = GameObject.Find("PopupCanvas");
        popup.SetActive(true);
        popup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Equip";
        popup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = $"장착하시겠습니까?";
        popup.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        popup.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    }

    void PopupEquipClear()
    {
        GameObject popup = GameObject.Find("PopupCanvas");
        popup.SetActive(true);
        popup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Equip";
        popup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "장착해제하시겠습니까?";
        popup.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        popup.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    }

}

