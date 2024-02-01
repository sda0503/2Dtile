using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{


    public Text[] textList ;
    public GameObject player;
    Rabbit rabbit;

    public GameObject expImage;

    Image exp;

    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
        exp = expImage.GetComponent<Image>();
    }


    void Start()
    {
        CheckStatus();
    }

    public string GetCommaText(int data) 
    { 
        return string.Format("{0:#,###}", data); 
    }

    public void Work()
    {
        Debug.Log("½ÇÇà");
        rabbit.money += rabbit.lv * 1000;
        rabbit.exp += 2;
        rabbit.CheckPlayerStatus();
        exp.fillAmount = (float)rabbit.exp / (float)rabbit.maxExp;
        CheckStatus();
    }

    void CheckStatus()
    {
        textList[0].text = rabbit.datas[0];
        textList[1].text = rabbit.datas[1];
        textList[2].text = rabbit.datas[2];
        textList[3].text = rabbit.lv.ToString();
        textList[4].text = rabbit.exp.ToString();
        textList[5].text = rabbit.maxExp.ToString();
        textList[6].text = GetCommaText(rabbit.money);
        textList[7].text = rabbit.inventory.Count.ToString();
        textList[8].text = rabbit.maxInventoty.ToString();
    }
}
