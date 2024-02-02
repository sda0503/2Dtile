using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    Rabbit rabbit;
    public GameObject back;

    public GameObject itemPrefab;
    Item item;

    

    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
        item = itemPrefab.GetComponent<Item>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeInventoty();
        SetInventoty();
    }

    void MakeInventoty() 
    {
        for (int i = 0; i < rabbit.maxInventory; i++)
        {
            float x = (i % 4) * 120f - 180f + 1570f;
            float y = (i / 4) * -120f + 200f + 540f;
            Instantiate(back, new Vector3(x, y,0), Quaternion.identity, transform);
        }
    }

    void SetInventoty()
    {
        for (int i = 0; i < rabbit.inventory.Count; i++)
        {
            item.iNum = i;
            float x = (i % 4) * 120f - 180f + 1570f;
            float y = (i / 4) * -120f + 200f + 540f;
            Instantiate(itemPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
    }
}