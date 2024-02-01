using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject back;
    Rabbit rabbit;

    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeInventoty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeInventoty() 
    {
        Debug.Log("½ÇÇà");
        for (int i = 0; i < rabbit.maxInventory; i++)
        {
         
            float x = (i % 4) * 120f - 180f + 1570f;
            float y = (i / 4) * -120f + 200f + 540f;
            Instantiate(back, new Vector3(x, y,0), Quaternion.identity, transform);
        }
    }
}
