using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject timeObj;
    public GameObject[] boards;
    public Text targetText;
    private string texts;
    private float delay = 0.125f;
    float time = 10f;
    bool timerStart = false;

    public Text lifeText;
    public GameObject choiceText;
    public GameObject endCanvas;
    int playerHp = 3;

    int saveScore;
    public Text maxScore;
    public Text currentScore;

    int i = 0;
    int count = 0;
    bool playerSelect;

    public AudioSource audioSource;
    public AudioClip[] audio_BGM;

    public AudioSource effectSource;
    public AudioClip[] effect_BGM;

    List<(string, string, bool)> quizList = new List<(string, string, bool)>();

    void Start()
    {
        quizList.Add(("상식 문제 입니다.\r\n\r\n게의 다리는 모두 10개이다.", "게의 다리는 모두 10개 입니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("과학 문제 입니다.\r\n\r\n사람의 땀은 알카리성이다.", "사람의 땀은 산성 입니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("상식 문제 입니다.\r\n\r\n우리나라에서 최초로 지정된 구립 공원은 지리산이다.", "지리산 1967년, 설악산 1969년에 지정되었습니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("상식 문제 입니다.\r\n\r\n대머리도 비듬이 생긴다.", "대머리도 비듬이 생깁니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("과학 문제 입니다.\r\n\r\n위가 없어도 사람은 살 수 있다.", "장이 위의 역할을 대신합니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("과학 문제 입니다.\r\n\r\n비행기의 블랙박스는 검은색이다.", "오랜지 색입니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("상식 문제 입니다.\r\n\r\n머리를 자주 감으면 머리카락이 빠진다.", "머리를 잘안감으면 머리가 빠집니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("과학 문제 입니다.\r\n\r\n물은 100도에서 끓는다.", "물의 끓는 점은 기압에 따라 다릅니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("과학 문제 입니다.\r\n\r\n번개는 남자보다 여자를 칠 가능성이 많다.", "남자가 번개 맞을 확률이 여성보다 6배나 많다. \r\n\r\n 정답은 ", false));
        quizList.Add(("상식 문제 입니다.\r\n\r\n하마는 육식 동물이다.", "하마는 초식 동물입니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("상식 문제 입니다.\r\n\r\n로댕의 생각하는 사람은 눈을 감고 있다.", "눈을 뜨고 있습니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("상식 문제 입니다.\r\n\r\n서울에서 가장 오래된 성당은 명동성당이다.", "약현성당 1892년, 명동성당 1898년에 완공되었습니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("역사 문제 입니다.\r\n\r\n조선 물건 쓰기 운동을 적극적으로 후원했던 당시의 신문사는 조선일보이다.", "동아일보입니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("역사 문제 입니다.\r\n\r\n한국의 국조는 까치이다.", "관습상으로 인정하지만 법적으로 인정하지 않습니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("상식 문제 입니다.\r\n\r\n전동 킥보드를 술마시고 타면 음주운전이다.", "전동 킥보드는 원동기 면허가 필요하며 음주 후 이용하면 음주운전입니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("상식 문제 입니다.\r\n\r\n수컷 캥거루가 앞발을 들고 권투하는 모습을 보여주는 것은 암컷에 대한 프로포즈 자세입니다.", "그렇다고 합니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("역사 문제 입니다.\r\n\r\n옛 서당에도 오늘날 처럼 반장을 뽑았다", "그렇다고 합니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("문학 문제 입니다.\r\n\r\n셰익스피어의 4개 비극 중 리어왕의 주인공에겐 3명의 딸이 있다.", "그렇다고 합니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("상식 문제 입니다.\r\n\r\n달걀은 어린 닭이 낳은 것일수록 그 크기가 크다.", "어린 닭이 낳은 달걀은 크기가 작은편입니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("과학 문제 입니다.\r\n\r\n사슴의 뿔은 매년 빠졌다 다시난다.", "사슴의 뿔은 매년 다시 납니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("수학 문제 입니다.\r\n\r\n2+2*2 = 8이다.", " 2+2*2는 2+4로 6입니다. \r\n\r\n 정답은 ", false));
        quizList.Add(("문학 문제 입니다.\r\n\r\n별주부전의 별주부는 거북이다", "별주부전의 별주부는 자라다 \r\n\r\n 정답은 ", false));
        quizList.Add(("영화 문제 입니다.\r\n\r\n대한민국에서 가장 흥행한 한국영화는 명량이다.", "1위 명랑, 2위 극한직업, 3위 신과함께:죄와 벌 \r\n\r\n 정답은 ", true));
        quizList.Add(("역사 문제 입니다.\r\n\r\n스페인의 사그라다 파밀리아 대성당은 아직까지도 공사 진행중인 성당이다.", "1882년에 착공하여 아직까지도 공사 진행중이다. \r\n\r\n 정답은 ", true));
        quizList.Add(("상식 문제 입니다.\r\n\r\n세계에서 가장 높은 건물은 부르즈 할리파이다. 부르즈 할리파의 높이는 800M 보다 높다.", "부르즈 할리파의 높이는 828M이다. \r\n\r\n 정답은 ", true));
        quizList.Add(("수학 문제 입니다.\r\n\r\n현재 원주율의 소수점 자리수는 62조8천억번째 자리까지 발견되었다.", "스위스 그라운뷘덴 응용과학대에서 108일 9시간에 걸쳐 계산하였다. \r\n\r\n 정답은 ", true));
        quizList.Add(("역사 문제 입니다.\r\n\r\n세계 최초의 법전은 함무라비법전이다.", "고대 바빌로니아의 함무라비왕이 제정한 함무라비법전이 세계에서 가장오래된 법전이다. \r\n\r\n 정답은 ", true));
        quizList.Add(("지리 문제 입니다.\r\n\r\n대한민국에서 지정한 여행금지 지역에 필리핀이 포함되어 있다.", "대한민국에서 지정한 여행금지 지역은 필리핀,러시아,벨라루스 일부지역 입니다. \r\n\r\n 정답은 ", true));
        quizList.Add(("지리 문제 입니다.\r\n\r\n대한민국에서 최서단은 백령도이다.", "대한민국의 최서단은 인천광역시 옹진군 백령면 연화리로 백령도이다. \r\n\r\n 정답은 ", true));
        quizList.Add(("상식 문제 입니다.\r\n\r\n세계에서 인구가 제일 많은 국가는 중국이다.", "유엔이 추정하기에 인구가 제일 많은 국가는 인도이다.  \r\n(약14억 2천 800만명) \r\n\r\n 정답은 ", false));
        StartQuiz();

        audioSource.clip = audio_BGM[0];
        audioSource.Play();
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
                AnswerText(i);
            }
        }
    }

    void StartQuiz()
    {
        choiceText.SetActive(false);
        boards[0].SetActive(true);
        boards[1].SetActive(false);
        i = Random.Range(0, quizList.Count);
        texts = quizList[i].Item1;
        targetText.text = "";
        StartCoroutine(TextCoroutine());
    }

    //글자 한글자씩 나오게
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


    //클릭 이벤트
    public void OnClickBtn(bool click)
    {
        choiceText.SetActive(true);
        choiceText.transform.GetChild(0).gameObject.GetComponent<Text>().text = click ? "O" : "X";
        playerSelect = click;

        effectSource.clip = effect_BGM[0];
        effectSource.Play();
    }

    //정답 보이기
    void AnswerText(int index)
    {
        boards[0].SetActive(false);
        boards[1].SetActive(true);
        boards[1].GetComponent<Text>().text = texts = quizList[index].Item2 + (quizList[index].Item3 ? "O" : "X");

        if (!choiceText.activeSelf || (choiceText.activeSelf && playerSelect != quizList[index].Item3))
        {
            playerHp--;
            effectSource.clip = effect_BGM[1];
            effectSource.Play();
        }
        else
        {
            count++;
            effectSource.clip = effect_BGM[2];
            effectSource.Play();
        }
        quizList.RemoveAt(index);
        if (playerHp > 0) Invoke("StartQuiz", 5f);
        else
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = audio_BGM[1];
            audioSource.Play();
            endCanvas.SetActive(true);
            
            saveScore = PlayerPrefs.GetInt("BestScore");
            if (saveScore < count)
            {
                PlayerPrefs.SetInt("BestScore", count);
                saveScore = count;
            }
            maxScore.text = saveScore.ToString();
            currentScore.text = count.ToString();
        }
    }
    
}
