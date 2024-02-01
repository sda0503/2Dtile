using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public string[] datas = new string[3];
    public int lv =0;
    public int exp = 0;
    public int maxExp = 0;
    public int money = 0;

    public List<int> inventory = new List<int>();
    public int maxInventoty = 10;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        datas[0] = "±Í¿°Åä³¢";
        datas[1] = "Åä¹ðÀÌ";
        datas[2] = "½º½º·Î ±Í¿±´Ù »ý°¢ÇÏ°í ÀÖ´Â Åä³¢";
        lv = 1;
        exp = 0;
        maxExp = 10;
        money = 100034587;
    }

     void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        if(mousePos.x < 0)
        {
            transform.position = new Vector3(1.56f, 2.67f, 1);
            transform.localScale = new Vector3(-4,4,1);
        }
        else if(mousePos.x > 0)
        {
            transform.position = new Vector3(-1.31f, 2.67f, 1);
            transform.localScale = new Vector3(4, 4, 1);
        }
    }

    public void CheckPlayerStatus()
    {
        if(exp >= maxExp)
        {
            lv++;
            exp -= maxExp;
            maxExp = lv * 10;
        }
    }
}
