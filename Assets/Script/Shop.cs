using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    public GameObject itemManager;
    ItemManager itemList;
    //아이템 리스트
    public GameObject itemListPrefab;

    //실제 아이템 프리펨
    public GameObject itemP;
    Item item;
    Text[] textList = new Text[4];
    Image[] imageLset = new Image[2];
    List<int> temp = new List<int>();

    public Sprite[] images;

    void Awake()
    {
        itemList = itemManager.GetComponent<ItemManager>();
        item = itemP.GetComponent<Item>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        textList[0] = itemListPrefab.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        textList[1] = itemListPrefab.transform.GetChild(1).GetChild(1).GetComponent<Text>();
        textList[2] = itemListPrefab.transform.GetChild(4).GetChild(1).GetComponent<Text>();
        textList[3] = itemListPrefab.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        imageLset[0] = itemListPrefab.transform.GetChild(4).GetComponent<Image>();
        imageLset[1] = itemListPrefab.transform.GetChild(4).GetChild(0).GetComponent<Image>();
        MakeList();
    }


    void MakeList()
    {
        temp.Clear();
        for (int i = 0; i < 4; i++)
        {
            //랜덤한수 4개 뽑기
            int rand = Random.Range(0, itemList.items.Count);
            while(temp.Contains(rand))
            {
                rand = Random.Range(0, itemList.items.Count);
            }
            temp.Add(rand);
            float x = 960f;
            float y = i * -180f + 770f;
            itemListPrefab.transform.GetChild(0).GetComponent<Image>().sprite = item.itemImages[itemList.items[rand].iNum];
            textList[0].text = itemList.items[rand].itemName;
            textList[1].text = itemList.items[rand].desc;
            textList[2].text = "+" + itemList.items[rand].power.ToString();
            textList[3].text = GetCommaText(itemList.items[rand].gold);
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

}
