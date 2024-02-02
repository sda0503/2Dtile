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
        AddItemList(0, "�α��� �尩", "�α��� õ���� ���� �尩, ��� �ʴ��ʴ� �� ���δ�.",10000, ItemType.ARMORHAND,2);
        AddItemList(1, "���� �尩", "�������� ���� �尩, ���� ��ȣ�ϱ⿡ ���� �尩", 20000, ItemType.ARMORHAND, 4);
        AddItemList(13, "�α��� õ�Ź�", "�� ������ õ�� ��� ���� �Ź�, �̹����� ���� ��ȣ�� ������ ���� ������.", 10000, ItemType.ARMORFOOT, 2);
        AddItemList(14, "���� �Ź�", "�������� ���� �Ź�, ���밨�� ���� ���� ������ �ʴ� .", 30000, ItemType.ARMORFOOT, 4);
        AddItemList(26, "��������", "����� ���� ����� �ٹ̱���̴�.", 10000, ItemType.ACCESSORY, 2);
        AddItemList(36, "���޶��� �����", "���޶��带 �����Ͽ� ���� ����� ������ ����� �����ش�.", 50000, ItemType.ACCESSORY, 5);
        AddItemList(41, "1ĳ�� ���̾Ƹ�� ����", "ûȥ�� �� ����ϱ� ���� ���̾Ƹ�� ����", 4380000, ItemType.ACCESSORY, 20);
        AddItemList(48, "����������", "������ ��� ���� ������", 10000, ItemType.WEAPON, 5);
        AddItemList(60, "ö������", "ö�� ����� �Ͽ� ���� ������", 100000, ItemType.WEAPON, 15);
        AddItemList(79, "Ȳ�ݸ�����", "ǰ�� ���� ö�� �����ѵ� ���� �Ͽ� ���� ������", 10000000, ItemType.WEAPON, 50);
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
