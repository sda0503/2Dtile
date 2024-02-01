using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{


    public Text[] textList ;
    public GameObject player;
    Rabbit rabbit;

    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
    }


    void Start()
    {
        //√ ±‚»≠
        textList[0].text = rabbit.datas[0] ;
        textList[1].text = rabbit.datas[1];
        textList[2].text = rabbit.datas[2];
        textList[3].text = rabbit.lv.ToString();
        textList[4].text = rabbit.exp.ToString();
        textList[5].text = rabbit.maxExp.ToString();
        textList[6].text = GetCommaText(rabbit.money);
    }

    void Update()
    {

    }

    public string GetCommaText(int data) 
    { 
        return string.Format("{0:#,###}", data); 
    }
}
