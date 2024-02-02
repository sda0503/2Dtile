using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public static GameManager instance = null;
    public Text playername;
    public Text realTime;
    public Text myName;
    public GameObject panel;
    public GameObject userList;
    public GameObject charList;
    public InputField playerNameInput;
    public GameObject talkPanel;
    public GameObject scanObject;
    public Text talkText;
    public bool isAction;
    public int talkIndex;


    string nickname;
    public bool isUserListOn = false;
    public bool isChange = false;
    bool isCharListOn = false;
    public bool isPanel = true;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Debug.Log("날아감");
                Destroy(this.gameObject);
            }
        }
        nickname = playerNameInput.GetComponent<InputField>().text;
    }

    private void Update()
    {
        realTime.text =  DateTime.Now.ToString(("HH:mm"));
    }

    public void EnterName()
    {
        nickname = playerNameInput.text;
        if(nickname.Length < 2)
        {
            Debug.Log("더 많은 글자수가 필요합니다.");
            return;
        }
        else
        {
            isPanel = false;
            playername.text = nickname;
            myName.text = nickname;
            panel.SetActive(isPanel);
        }
    }

    public void ChoiceName()
    {
        isPanel = true;

        playerNameInput.text = null;
        panel.SetActive(isPanel);
    }

    public void ChoiceChar()
    {
        if (!isCharListOn)
        {
            isCharListOn = true;
        }
        else
        {
            isCharListOn = false;
        }
        charList.SetActive(isCharListOn);
    }

    public void Select1()
    {
        isChange = false;
        charList.SetActive(false);
        isCharListOn = false;
    }

    public void Select2()
    {
        isChange = true;
        charList.SetActive(false);
        isCharListOn = false;
    }

    public void CheckUser()
    {

        if (!isUserListOn)
        {
            isUserListOn = true;
        }
        else
        {
            isUserListOn = false;
        }
        userList.SetActive(isUserListOn);
    }
    

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;

            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }

    //대화 이벤트
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        objData objd = scanObject.GetComponent<objData>();
        Talk(objd.id, objd.isNpc);
        talkPanel.SetActive(isAction);

    }
}
