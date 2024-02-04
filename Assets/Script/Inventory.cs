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
            switch (transform.GetChild(x).GetComponent<Item>().type)
            {
                case ItemType.WEAPON: transform.GetChild(x).GetComponent<Item>().atk = transform.GetChild(x).GetComponent<Item>().power; break;
                case ItemType.ARMORBODY: transform.GetChild(x).GetComponent<Item>().def = transform.GetChild(x).GetComponent<Item>().power; break;
                case ItemType.ARMORHEAD: transform.GetChild(x).GetComponent<Item>().def = transform.GetChild(x).GetComponent<Item>().power; break;
                case ItemType.ARMORHAND: transform.GetChild(x).GetComponent<Item>().cri = transform.GetChild(x).GetComponent<Item>().power; break;
                case ItemType.ARMORFOOT: transform.GetChild(x).GetComponent<Item>().def = transform.GetChild(x).GetComponent<Item>().power; break;
                case ItemType.ACCESSORY: transform.GetChild(x).GetComponent<Item>().hp = transform.GetChild(x).GetComponent<Item>().power; break;
            }
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
            clickObj.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            CheckEquip(true);
            clickObj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void CheckEquip(bool ft)
    {
        //중복 체크 체크 끄기
        for (int i = 0; i < rabbit.inventory.Count; i++)
        {
            int x = i + 21;
            if (transform.GetChild(x).GetComponent<Item>() != clickObj.GetComponent<Item>())
            {
                if(transform.GetChild(x).GetComponent<Item>().isEquip)
                {
                    //타입에 따라 값을 먼저 빼줌
                    switch (transform.GetChild(x).GetComponent<Item>().type)
                    {
                        case ItemType.WEAPON: rabbit.statis[0] -= transform.GetChild(x).GetComponent<Item>().atk; break;
                        case ItemType.ARMORBODY: rabbit.statis[1] -= transform.GetChild(x).GetComponent<Item>().def; break;
                        case ItemType.ARMORHEAD: rabbit.statis[1] -= transform.GetChild(x).GetComponent<Item>().def; break;
                        case ItemType.ARMORHAND: rabbit.statis[3] -= transform.GetChild(x).GetComponent<Item>().cri; break;
                        case ItemType.ARMORFOOT: rabbit.statis[1] -= transform.GetChild(x).GetComponent<Item>().def; break;
                        case ItemType.ACCESSORY: rabbit.statis[2] -= transform.GetChild(x).GetComponent<Item>().hp; break;
                    }
                }
            }
            //클릭한거랑 타입이 같은 아이템에만 작동
            if (clickObj.GetComponent<Item>().type == transform.GetChild(x).GetComponent<Item>().type)
            {
                transform.GetChild(x).GetComponent<Item>().isEquip = false;
                transform.GetChild(x).GetChild(0).gameObject.SetActive(false);
                clickObj.GetComponent<Item>().isEquip = ft;
            }
            
        }
  
         switch (clickObj.GetComponent<Item>().type)
         {
             case ItemType.WEAPON: rabbit.statis[0] += ft ? clickObj.GetComponent<Item>().atk : -clickObj.GetComponent<Item>().atk; break;
             case ItemType.ARMORBODY: rabbit.statis[1] += ft ?clickObj.GetComponent<Item>().def :-clickObj.GetComponent<Item>().def; break;
             case ItemType.ARMORHEAD: rabbit.statis[1] += ft ?clickObj.GetComponent<Item>().def :-clickObj.GetComponent<Item>().def; break;
             case ItemType.ARMORHAND: rabbit.statis[3] += ft ?clickObj.GetComponent<Item>().cri :-clickObj.GetComponent<Item>().cri; break;
             case ItemType.ARMORFOOT: rabbit.statis[1] += ft ?clickObj.GetComponent<Item>().def :-clickObj.GetComponent<Item>().def; break;
             case ItemType.ACCESSORY: rabbit.statis[2] += ft ? clickObj.GetComponent<Item>().hp :-clickObj.GetComponent<Item>().hp; break;
         }

        InfoManager.instance.CheckStatus();


        clickObj.transform.GetChild(0).gameObject.SetActive(ft);
        
    }
}
