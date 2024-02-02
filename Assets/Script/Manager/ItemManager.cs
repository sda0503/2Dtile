using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public GameObject itemIndex;
    // Start is called before the first frame update
    void Start()
    {
        AddItemList(0, "싸구려 장갑", "싸구려 천으로 만든 장갑, 어딘가 너덜너덜 해 보인다.",10000, ItemType.ARMORHAND,2);
        AddItemList(1, "가죽 장갑", "가죽으로 만든 장갑, 손을 보호하기에 좋은 장갑", 20000, ItemType.ARMORHAND, 4);
        AddItemList(13, "싸구려 천신발", "질 안좋은 천을 모아 만든 신발, 이물질로 부터 보호해 주지만 발이 아프다.", 10000, ItemType.ARMORFOOT, 2);
        AddItemList(14, "가죽 신발", "가죽으로 만든 신발, 착용감이 좋고 발이 아프지 않다 .", 30000, ItemType.ARMORFOOT, 4);
        AddItemList(26, "비즈목걸이", "비즈로 만든 목걸이 꾸미기용이다.", 10000, ItemType.ACCESSORY, 2);
        AddItemList(36, "에메랄드 목걸이", "에메랄드를 가공하여 만든 목걸이 안좋은 기운을 막아준다.", 50000, ItemType.ACCESSORY, 5);
        AddItemList(41, "1캐럿 다이아몬드 반지", "청혼할 때 사용하기 좋은 다이아몬드 반지", 4380000, ItemType.ACCESSORY, 20);
        AddItemList(48, "나무몽둥이", "나무를 깍아 만든 몽둥이", 10000, ItemType.WEAPON, 5);
        AddItemList(60, "철몽둥이", "철을 담금질 하여 만든 몽둥이", 100000, ItemType.WEAPON, 15);
        AddItemList(79, "황금몽둥이", "품질 좋은 철을 가공한뒤 도금 하여 만든 몽둥이", 10000000, ItemType.WEAPON, 50);
    }

    void AddItemList(int index, string name, string desc, int gold, ItemType itemType, int pow)
    {
        Item item = itemIndex.AddComponent<Item>();
        item.iNum = index;
        item.itemName = name;
        item.desc = desc;
        item.gold = gold;
        item.type = itemType;
        item.power = pow;
        items.Add(item);
    }
}
