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
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n���� �ٸ��� ��� 10���̴�.", "���� �ٸ��� ��� 10�� �Դϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n����� ���� ��ī�����̴�.", "����� ���� �꼺 �Դϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n�츮���󿡼� ���ʷ� ������ ���� ������ �������̴�.", "������ 1967��, ���ǻ� 1969�⿡ �����Ǿ����ϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n��Ӹ��� ����� �����.", "��Ӹ��� ����� ����ϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���� ��� ����� �� �� �ִ�.", "���� ���� ������ ����մϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n������� ���ڽ��� �������̴�.", "������ ���Դϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n�Ӹ��� ���� ������ �Ӹ�ī���� ������.", "�Ӹ��� �߾Ȱ����� �Ӹ��� �����ϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���� 100������ ���´�.", "���� ���� ���� ��п� ���� �ٸ��ϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n������ ���ں��� ���ڸ� ĥ ���ɼ��� ����.", "���ڰ� ���� ���� Ȯ���� �������� 6�質 ����. \r\n\r\n ������ ", false));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n�ϸ��� ���� �����̴�.", "�ϸ��� �ʽ� �����Դϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n�δ��� �����ϴ� ����� ���� ���� �ִ�.", "���� �߰� �ֽ��ϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n���￡�� ���� ������ ������ �������̴�.", "�������� 1892��, ������ 1898�⿡ �ϰ��Ǿ����ϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���� ���� ���� ��� ���������� �Ŀ��ߴ� ����� �Ź���� �����Ϻ��̴�.", "�����Ϻ��Դϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n�ѱ��� ������ ��ġ�̴�.", "���������� ���������� �������� �������� �ʽ��ϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n���� ű���带 �����ð� Ÿ�� ���ֿ����̴�.", "���� ű����� ������ ���㰡 �ʿ��ϸ� ���� �� �̿��ϸ� ���ֿ����Դϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n���� Ļ�ŷ簡 �չ��� ��� �����ϴ� ����� �����ִ� ���� ���ƿ� ���� �������� �ڼ��Դϴ�.", "�׷��ٰ� �մϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n�� ���翡�� ���ó� ó�� ������ �̾Ҵ�", "�׷��ٰ� �մϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���ͽ��Ǿ��� 4�� ��� �� ������� ���ΰ����� 3���� ���� �ִ�.", "�׷��ٰ� �մϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n�ް��� � ���� ���� ���ϼ��� �� ũ�Ⱑ ũ��.", "� ���� ���� �ް��� ũ�Ⱑ �������Դϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n�罿�� ���� �ų� ������ �ٽó���.", "�罿�� ���� �ų� �ٽ� ���ϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n2+2*2 = 8�̴�.", " 2+2*2�� 2+4�� 6�Դϴ�. \r\n\r\n ������ ", false));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���ֺ����� ���ֺδ� �ź��̴�", "���ֺ����� ���ֺδ� �ڶ�� \r\n\r\n ������ ", false));
        quizList.Add(("��ȭ ���� �Դϴ�.\r\n\r\n���ѹα����� ���� ������ �ѱ���ȭ�� ���̴�.", "1�� ���, 2�� ��������, 3�� �Ű��Բ�:�˿� �� \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n�������� ��׶�� �Ĺи��� �뼺���� ���������� ���� �������� �����̴�.", "1882�⿡ �����Ͽ� ���������� ���� �������̴�. \r\n\r\n ������ ", true));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n���迡�� ���� ���� �ǹ��� �θ��� �Ҹ����̴�. �θ��� �Ҹ����� ���̴� 800M ���� ����.", "�θ��� �Ҹ����� ���̴� 828M�̴�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���� �������� �Ҽ��� �ڸ����� 62��8õ���° �ڸ����� �߰ߵǾ���.", "������ �׶��ᵧ ������д뿡�� 108�� 9�ð��� ���� ����Ͽ���. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���� ������ ������ �Թ��������̴�.", "��� �ٺ��δϾ��� �Թ������� ������ �Թ��������� ���迡�� ��������� �����̴�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���ѹα����� ������ ������� ������ �ʸ����� ���ԵǾ� �ִ�.", "���ѹα����� ������ ������� ������ �ʸ���,���þ�,����罺 �Ϻ����� �Դϴ�. \r\n\r\n ������ ", true));
        quizList.Add(("���� ���� �Դϴ�.\r\n\r\n���ѹα����� �ּ����� ��ɵ��̴�.", "���ѹα��� �ּ����� ��õ������ ������ ��ɸ� ��ȭ���� ��ɵ��̴�. \r\n\r\n ������ ", true));
        quizList.Add(("��� ���� �Դϴ�.\r\n\r\n���迡�� �α��� ���� ���� ������ �߱��̴�.", "������ �����ϱ⿡ �α��� ���� ���� ������ �ε��̴�.  \r\n(��14�� 2õ 800����) \r\n\r\n ������ ", false));
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

    //���� �ѱ��ھ� ������
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


    //Ŭ�� �̺�Ʈ
    public void OnClickBtn(bool click)
    {
        choiceText.SetActive(true);
        choiceText.transform.GetChild(0).gameObject.GetComponent<Text>().text = click ? "O" : "X";
        playerSelect = click;

        effectSource.clip = effect_BGM[0];
        effectSource.Play();
    }

    //���� ���̱�
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
