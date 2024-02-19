using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public GameObject player;
    Rabbit rabbit;

    public GameObject input;
    InputField bankInput;

    public GameObject nameInput;
    InputField targetInput;
    public GameObject popup;

    // Start is called before the first frame update
    void Awake()
    {
        rabbit = player.GetComponent<Rabbit>();
        bankInput = input.GetComponent<InputField>();
        targetInput = nameInput.GetComponent<InputField>();
    }
    public void SetMoney(int money)
    {
        bankInput.text = money.ToString();
    }

    public void SaveMoney()
    {
        if(rabbit.money >= Convert.ToInt32(bankInput.text))
        {
            rabbit.money -= Convert.ToInt32(bankInput.text);
            rabbit.bankMoney += Convert.ToInt32(bankInput.text);
            PopupShow("Bank",$"{bankInput.text} ���� �Ͽ����ϴ�.");
            InfoManager.instance.CheckStatus();
            bankInput.text = "0";
        }
        else
        {
            PopupShow("Fail", $"���� �ڱ��� �����մϴ�.");
        }
    }

    public void LoadMoney()
    {
        if (rabbit.bankMoney >= Convert.ToInt32(bankInput.text))
        {
            rabbit.bankMoney -= Convert.ToInt32(bankInput.text);
            rabbit.money += Convert.ToInt32(bankInput.text);
            PopupShow("Bank", $"{bankInput.text} ��� �Ͽ����ϴ�.");
            InfoManager.instance.CheckStatus();
        }
        else
        {
            PopupShow("Fail", $"���� �ڱ��� �����մϴ�.");
        }
    }

    public void SendMoney()
    {
        if (targetInput.text != "")
        {
            if (rabbit.money >= Convert.ToInt32(bankInput.text))
            {
                rabbit.money -= Convert.ToInt32(bankInput.text);
                PopupShow("Bank", $"{bankInput.text} ���� �Ͽ����ϴ�.");
                InfoManager.instance.CheckStatus();
                bankInput.text = "0";
            }
            else
            {
                PopupShow("Fail", $"���� �ڱ��� �����մϴ�.");
            }
        }
        else
        {
            PopupShow("Fail", $"�۱� ����� �̸��� Ȯ���ϼ���");
        }
        
    }

    void PopupShow(string title, string mes)
    {
        popup.SetActive(true);
        popup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = title;
        popup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = mes;
        popup.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
    }

    void PopupShow(string title, string mes, string target)
    {

        popup.SetActive(true);
        popup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = title;
        popup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = mes;
        popup.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
    }

}
