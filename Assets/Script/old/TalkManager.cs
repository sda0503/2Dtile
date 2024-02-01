using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    

    // Start is called before the first frame update
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "���� ������Ʈ��!", "�ڵ��� ��� �ִ�?" });
        talkData.Add(2000, new string[] { "���� ũ����̾�!", "������ �� �����ϰ� �־�?", "�� ������ ������ �̼��� �����ؾ���!" });
        talkData.Add(3000, new string[] { "���� ũ����̾�!", "������ �� �����ϰ� �־�?", "�� ������ ������ �̼��� �����ؾ���!" });
        talkData.Add(4000, new string[] { "������Ʈ�� �� �׿���", "������ �� �����ϰ� �־�?", "�� ������ ������ �̼��� �����ؾ���!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
}
