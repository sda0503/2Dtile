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


    // Start is called before the first frame update
    void Start()
    {
        datas[0] = "�Ϳ��䳢";
        datas[1] = "�����";
        datas[2] = "������ �Ϳ��� �����ϰ� �ִ� �䳢";
        lv = 1;
        exp = 0;
        maxExp = 10;
        money = 1000;
    }
}
