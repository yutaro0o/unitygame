using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Slider slider;

    public int playerHP;

    public GameObject playerPrefab;
    
    private float leftTime;
    private Text textTimer;

    private bool inGame;
    public Text textClear;
    public Text textGameOver;

    static int highScore = 0;

    private Text textResult;
    private Text textResultLife;
    private Text textResultTime;
    private Text textResultTotal;
    private Text textHighScore;
    public GameObject nextSceneButton;
    int currentscene = 1;

    private AudioSource audioSource;

    public AudioClip overSound;
    public AudioClip killSound;
    public AudioClip clearSound;

    private void Start()
    {
        playerHP = 10;
        slider = GameObject.Find("PlayerSlider").GetComponent<Slider>();
        //hpをSliderコンポーネントのmaxvalueを取得し体力満タンの状態でゲームを開始
        slider.maxValue = playerHP;

        textGameOver.enabled = false;
        textClear.enabled = false;
        nextSceneButton.SetActive(false);
        leftTime = 30f;
        audioSource = gameObject.AddComponent<AudioSource>();
        textTimer = GameObject.Find("TimeText").GetComponent<Text>();

        textResult = GameObject.Find("Result Score").GetComponent<Text>();
        textResultTime = GameObject.Find("Result Time").GetComponent<Text>();
        textResultTotal = GameObject.Find("Result Total").GetComponent<Text>();
        textHighScore = GameObject.Find("HighScore").GetComponent<Text>();

        SetHighScoreText(highScore);
        inGame = true;
    }

    private void SetHighScoreText(int highScore)
    {
        textHighScore.text = "HighScore:" + highScore.ToString();
    }

    public bool IsInGame()
    {
        return inGame;
    }

    private void Update()
    {
        if (inGame)//ゲーム中の時
        {
            leftTime -= Time.deltaTime;
            textTimer.text = "Time:" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");
            if (leftTime < 0f)
            {
                audioSource.PlayOneShot(overSound);
                textGameOver.enabled = true;
                inGame = false;
            }

            GameObject　playerObj = GameObject.Find("Player");
            if (playerObj == null)
            {
                --playerHP;
                if (playerHP > 0)
                {
                    audioSource.PlayOneShot(killSound);
                    GameObject newPlayer = Instantiate(playerPrefab);
                    newPlayer.name = playerPrefab.name;
                }
                else
                {
                    playerHP = 0;
                    audioSource.PlayOneShot(overSound);
                    textGameOver.enabled = true;
                    inGame = false;
                }
            }
            GameObject targetObj = GameObject.FindWithTag("Target");
            if (targetObj == null)
            {
                audioSource.PlayOneShot(clearSound);
                textClear.enabled = true;
                nextSceneButton.SetActive(true);

                int scoreLife = playerHP * 1000;
                int scoreTime = (int)(leftTime * 100f);
                textResultTime.text = "Time * 100 = " + scoreTime.ToString();

                int totalScore = scoreLife + scoreTime;
                textResultTotal.text = "Total Score:" + totalScore.ToString();

                if (highScore < totalScore)
                {
                    highScore = totalScore;
                    SetHighScoreText(highScore);
                }

                inGame = false;
            }
        }
    }

    public void Replay()
    {
        int sceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneindex);
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("opening");
    }

    public void NextScene()
    {
        currentscene++;
        SceneManager.LoadScene(currentscene);
    }
}
