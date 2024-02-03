using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Item;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    Rabbit rabbit;
    public GameObject back;

    public GameObject itemPrefab;
    Item item;
    Button itemClick;

    public GameObject popup;

    Button btnConfirm;

    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
        item = itemPrefab.GetComponent<Item>();
        MakeInventoty();
        btnConfirm = popup.transform.GetChild(1).GetChild(2).gameObject.GetComponent<Button>();
        btnConfirm.onClick.AddListener((Confirm));
    }

    void MakeInventoty() 
    {
        for (int i = 0; i < rabbit.maxInventory; i++)
        {
            float x = (i % 4) * 120f - 180f + 1570f;
            float y = (i / 4) * -120f + 200f + 540f;
            Instantiate(back, new Vector3(x, y,0), Quaternion.identity, transform);
     
        }
        for (int i = 0; i < rabbit.maxInventory; i++)
        {
            float x = (i % 4) * 120f - 180f + 1570f;
            float y = (i / 4) * -120f + 200f + 540f;
            itemPrefab.SetActive(false);
            Instantiate(itemPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
       
    }

    public void SetInventoty()
    {
        for (int i = 0; i < rabbit.inventory.Count; i++)
        {
            int x = i + 21;
            transform.GetChild(x).gameObject.SetActive(true);
            itemClick = transform.GetChild(x).GetComponent<Button>();
            itemClick.onClick.AddListener((OnEquip));
            transform.GetChild(x).GetComponent<Image>().sprite = item.itemImages[rabbit.inventory[i].Item1.iNum];
            transform.GetChild(x).GetComponent<Item>().iNum = rabbit.inventory[i].Item1.iNum;
            transform.GetChild(x).GetComponent<Item>().itemName = rabbit.inventory[i].Item1.itemName;
            transform.GetChild(x).GetComponent<Item>().desc = rabbit.inventory[i].Item1.desc;
            transform.GetChild(x).GetComponent<Item>().type = rabbit.inventory[i].Item1.type;
            transform.GetChild(x).GetComponent<Item>().power = rabbit.inventory[i].Item1.power;
        }
    }

    GameObject clickObj;
    public void OnEquip()
    {
        clickObj = EventSystem.current.currentSelectedGameObject;
        if (clickObj.GetComponent<Item>().isEquip)
        {
            PopupEquipClear();
        }
        else
        {
            PopupEquip();
        }
    }

    void PopupEquip()
    {
        popup.SetActive(true);
        popup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Equip";
        popup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = $"아이템 명 : {clickObj.GetComponent<Item>().itemName}\n해당 아이템을 장착 하시겠습니까?";
        popup.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        popup.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    }

    void PopupEquipClear()
    {
        popup.SetActive(true);
        popup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Equip";
        popup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = $"아이템 명 : {clickObj.GetComponent<Item>().itemName}\n해당 아이템을 장착해제 하시겠습니까?";
        popup.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        popup.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    }


    void Confirm()
    {
        if (clickObj.GetComponent<Item>().isEquip)
        {
            CheckEquip(false);
            SetPow(false);
            clickObj.GetComponent<Item>().isEquip = false;
            clickObj.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            clickObj.GetComponent<Item>().isEquip = true;
            CheckEquip(true);
            SetPow(true);
            clickObj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void CheckEquip(bool ft)
    {
        //중복 체크 이어서 하기
        for (int i = 0; i < rabbit.inventory.Count; i++)
        {
            if (clickObj.GetComponent<Item>().type == rabbit.inventory[i].Item1.type)
            {
                rabbit.inventory[i].Item1.isEquip = false;
                
            }
        }

        switch (clickObj.GetComponent<Item>().type)
        {
            case ItemType.WEAPON: rabbit.equipItems[0] = ft; break;
            case ItemType.ARMORBODY: rabbit.equipItems[1] = ft; break;
            case ItemType.ARMORHEAD: rabbit.equipItems[2] = ft; break;
            case ItemType.ARMORHAND: rabbit.equipItems[3] = ft; break;
            case ItemType.ARMORFOOT: rabbit.equipItems[4] = ft; break;
            case ItemType.ACCESSORY: rabbit.equipItems[5] = ft; break;
        }
        transform.GetChild(0).gameObject.SetActive(ft);

        

    }


    public void SetPow(bool ft)
    {
        switch (clickObj.GetComponent<Item>().type)
        {
            case ItemType.WEAPON: clickObj.GetComponent<Item>().atk = clickObj.GetComponent<Item>().power; break;
            case ItemType.ARMORBODY: clickObj.GetComponent<Item>().def = clickObj.GetComponent<Item>().power; break;
            case ItemType.ARMORHEAD: clickObj.GetComponent<Item>().def = clickObj.GetComponent<Item>().power; break;
            case ItemType.ARMORHAND: clickObj.GetComponent<Item>().cri = clickObj.GetComponent<Item>().power; break;
            case ItemType.ARMORFOOT: clickObj.GetComponent<Item>().def = clickObj.GetComponent<Item>().power; break;
            case ItemType.ACCESSORY: clickObj.GetComponent<Item>().hp = clickObj.GetComponent<Item>().power; break;
        }
        rabbit.statis[0] += ft ? clickObj.GetComponent<Item>().atk : -clickObj.GetComponent<Item>().atk;
        rabbit.statis[1] += ft ? clickObj.GetComponent<Item>().def : -clickObj.GetComponent<Item>().def;
        rabbit.statis[2] += ft ? clickObj.GetComponent<Item>().hp : -clickObj.GetComponent<Item>().hp;
        rabbit.statis[3] += ft ? clickObj.GetComponent<Item>().cri : -clickObj.GetComponent<Item>().cri;
        InfoManager.instance.CheckStatus();
    }
}
