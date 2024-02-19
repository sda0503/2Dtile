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

    public List<UserData> userDate = new List<UserData>();

    public static InfoManager instance;


    void Awake()
    {
        instance = this;
        rabbit = player.GetComponent<Rabbit>();
        exp = expImage.GetComponent<Image>();
    }


    void Start()
    {
        textList[0].text = rabbit.datas[0];
        textList[1].text = rabbit.datas[1];
        textList[2].text = rabbit.datas[2];
        CheckStatus();
    }

    public string GetCommaText(int data) 
    { 
        return string.Format("{0:#,###}", data); 
    }

    public void Work()
    {
        rabbit.money += rabbit.lv * 1000;
        rabbit.exp += 2;
        rabbit.CheckPlayerStatus();
        CheckStatus();
    }

    public void CheckStatus()
    {
        textList[3].text = rabbit.lv.ToString();
        textList[4].text = rabbit.exp.ToString();
        textList[5].text = rabbit.maxExp.ToString();
        textList[6].text = rabbit.money == 0 ? "0" : GetCommaText(rabbit.money);
        textList[7].text = rabbit.inventory.Count.ToString();
        textList[8].text = rabbit.maxInventory.ToString();
        textList[9].text = rabbit.statis[0].ToString();
        textList[10].text = rabbit.statis[1].ToString();
        textList[11].text = rabbit.statis[2].ToString();
        textList[12].text = rabbit.statis[3].ToString();
        textList[13].text = rabbit.bankMoney == 0 ? "0" : GetCommaText(rabbit.bankMoney);
        textList[14].text = rabbit.money == 0 ? "0" : GetCommaText(rabbit.money);
        exp.fillAmount = (float)rabbit.exp / (float)rabbit.maxExp;
    }

    
}
