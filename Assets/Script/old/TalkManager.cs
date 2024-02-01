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
        talkData.Add(1000, new string[] { "나는 임포스트야!", "코딩은 재미 있니?" });
        talkData.Add(2000, new string[] { "나는 크루원이야!", "과제는 잘 수행하고 있어?", "맵 곳곳에 숨겨진 미션을 수행해야해!" });
        talkData.Add(3000, new string[] { "나는 크루원이야!", "과제는 잘 수행하고 있어?", "맵 곳곳에 숨겨진 미션을 수행해야해!" });
        talkData.Add(4000, new string[] { "임포스트가 날 죽였어", "과제는 잘 수행하고 있어?", "맵 곳곳에 숨겨진 미션을 수행해야해!" });
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
