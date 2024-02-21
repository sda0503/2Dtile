using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject timeObj;
    public Text targetText;
    private string texts;
    private float delay = 0.125f;
    float time = 10f;
    bool timerStart = false;

    public Text lifeText;
    int playerHp = 3;

    bool playerSelect;

    void Start()
    {
        texts = targetText.text.ToString();
        targetText.text = "";
        StartCoroutine(TextCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = playerHp.ToString();
        if (timerStart)
        {
            timeObj.SetActive(true);
            time -= Time.deltaTime;
            timeObj.GetComponent<Text>().text = time.ToString("N0");
            if(time <= 0)
            {
                timeObj.SetActive(false);
                timerStart = false;
                time = 10f;
                StopCoroutine(TextCoroutine());
            }
        }
    }

    IEnumerator TextCoroutine()
    {
        int count = 0;

        while (count != texts.Length)
        {
            if (count < texts.Length)
            {
                targetText.text += texts[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(delay);
        }
        timerStart = true;
    }


    public void OnClickBtn(bool click)
    {
        playerSelect = click;
        Debug.Log("현재 선택한 버튼의 값은 " + click);
    }
}
