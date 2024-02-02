using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;
using Random = UnityEngine.Random;

public class Shop : MonoBehaviour
{
    public GameObject itemManager;
    ItemManager itemList;
    //아이템 리스트
    public GameObject itemListPrefab;

    //실제 아이템 프리펨
    public GameObject itemP;
    Item item;
    Text[] textList = new Text[5];
    Image[] imageLset = new Image[2];
    List<int> temp = new List<int>();

    public Sprite[] images;

    public Text time;
    public Text isRenew;
    double textTime;

    bool is_renew = true;

    void Awake()
    {
        itemList = itemManager.GetComponent<ItemManager>();
        item = itemP.GetComponent<Item>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        textTime = 60;

        textList[0] = itemListPrefab.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        textList[1] = itemListPrefab.transform.GetChild(1).GetChild(1).GetComponent<Text>();
        textList[2] = itemListPrefab.transform.GetChild(4).GetChild(1).GetComponent<Text>();
        textList[3] = itemListPrefab.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        textList[4] = itemListPrefab.transform.GetChild(2).GetChild(1).GetComponent<Text>();
        imageLset[0] = itemListPrefab.transform.GetChild(4).GetComponent<Image>();
        imageLset[1] = itemListPrefab.transform.GetChild(4).GetChild(0).GetComponent<Image>();
        MakeList();
    }

    void Update()
    {
        textTime -= Time.deltaTime;
        if (textTime < 0) 
        {
            is_renew = true;
            textTime = 60;
            SetList();
            is_renew = true;
        }
        time.text = TimeSpan.FromSeconds(textTime).ToString(@"mm\:ss");
        isRenew.text = is_renew ? "O" : "X";
    }

    public void SetList()
    {
        if (is_renew) 
        { 
            is_renew = false;
            temp.Clear();
            for (int i = 3; i < 7; i++)
            {
                textList[0] = transform.GetChild(i).gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>();
                textList[1] = transform.GetChild(i).gameObject.transform.GetChild(1).GetChild(1).GetComponent<Text>();
                textList[2] = transform.GetChild(i).gameObject.transform.GetChild(4).GetChild(1).GetComponent<Text>();
                textList[3] = transform.GetChild(i).gameObject.transform.GetChild(3).GetChild(0).GetComponent<Text>();
                imageLset[0] = transform.GetChild(i).gameObject.transform.GetChild(4).GetComponent<Image>();
                imageLset[1] = transform.GetChild(i).gameObject.transform.GetChild(4).GetChild(0).GetComponent<Image>();
                int rand = Random.Range(0, itemList.items.Count);
                while (temp.Contains(rand))
                {
                    rand = Random.Range(0, itemList.items.Count);
                }
                temp.Add(rand);
                transform.GetChild(i).gameObject.SetActive(true);
                transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = item.itemImages[itemList.items[rand].iNum];
                textList[0].text = itemList.items[rand].itemName;
                textList[1].text = itemList.items[rand].desc;
                textList[2].text = "+" + itemList.items[rand].power.ToString();
                textList[3].text = GetCommaText(itemList.items[rand].gold);
                ChangeType(rand);
            }
        }
    }

    public void MakeList()
    {
        temp.Clear();
        for (int i = 3; i < 7; i++)
        {
            int rand = Random.Range(0, itemList.items.Count);
            while (temp.Contains(rand))
            {
                rand = Random.Range(0, itemList.items.Count);
            }
            temp.Add(rand);
            float x = 960f;
            float y = i * -180f + 1310f;
            
            itemListPrefab.transform.GetChild(0).GetComponent<Image>().sprite = item.itemImages[itemList.items[rand].iNum];
            textList[0].text = itemList.items[rand].itemName;
            textList[1].text = itemList.items[rand].desc;
            textList[2].text = "+" + itemList.items[rand].power.ToString();
            textList[3].text = GetCommaText(itemList.items[rand].gold);
            textList[4].text = itemList.items[rand].iNum.ToString();
            itemListPrefab.SetActive(true);
            ChangeType(rand);
            Instantiate(itemListPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
    }


    string GetCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }

    void ChangeType(int index)
    {
        switch (itemList.items[index].type)
        {
            case ItemType.WEAPON:
                imageLset[0].sprite = images[0];
                imageLset[1].sprite = images[3];
                textList[2].color = new Color(44 / 255f, 170 / 255f, 250 / 255f);
                break;
            case ItemType.ARMORBODY:
                imageLset[0].sprite = images[0];
                imageLset[1].sprite = images[4];
                textList[2].color = new Color(44 / 255f, 170 / 255f, 250 / 255f);
                break;
            case ItemType.ARMORHEAD:
                imageLset[0].sprite = images[0];
                imageLset[1].sprite = images[4];
                textList[2].color = new Color(44 / 255f, 170 / 255f, 250 / 255f);
                break;
            case ItemType.ARMORHAND:
                imageLset[0].sprite = images[0];
                imageLset[1].sprite = images[3];
                textList[2].color = new Color(44 / 255f, 170 / 255f, 250 / 255f);
                break;
            case ItemType.ARMORFOOT:
                imageLset[0].sprite = images[0];
                imageLset[1].sprite = images[4];
                textList[2].color = new Color(44 / 255f, 170 / 255f, 250 / 255f);
                break;
            case ItemType.ACCESSORY:
                imageLset[0].sprite = images[1];
                imageLset[1].sprite = images[5];
                textList[2].color = new Color(19 / 255f, 216 / 255f, 140 / 255f);
                break;
        }
    }

    void BuyItem()
    {

    }

}
