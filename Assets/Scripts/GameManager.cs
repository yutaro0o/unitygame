using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Text textGameOver;

    private int score;
    private float leftTime;
    //private Text textScore;
    private Text textTimer;
    private bool inGame;
    public Text textClear;
    static int highScore = 0;

    private Text textResultScore;
    private Text textResultHP;
    private Text textResultTime;
    private Text textResultTotal;
    private Text textHighScore;
    public GameObject nextSceneButton;
    public static int i = 2;
    int lastscene = 4;

    PlayerHPBar playerhp;
    Player player;

    //private AudioSource audioSource;

    //public AudioClip overSound;
    //public AudioClip killSound;
    //public AudioClip clearSound;

    private void Start()
    {
        textGameOver.enabled = false;
        textClear.enabled = false;
        nextSceneButton.SetActive(false);
        score = 0;
        leftTime = 30f;
        //audioSource = gameObject.AddComponent<AudioSource>();
        //textScore = GameObject.Find("Score").GetComponent<Text>();
        //textLife = GameObject.Find("BallLife").GetComponent<Text>();
        textTimer = GameObject.Find("TimeText").GetComponent<Text>();

        //textResultScore = GameObject.Find("Result Score").GetComponent<Text>();
        textResultHP = GameObject.Find("Result HP").GetComponent<Text>();
        textResultTime = GameObject.Find("Result Time").GetComponent<Text>();
        textResultTotal = GameObject.Find("Result Total").GetComponent<Text>();
        textHighScore = GameObject.Find("HighScore").GetComponent<Text>();

        SetScoreText(score);
        SetHighScoreText(highScore);
        inGame = true;

        playerhp = playerPrefab.GetComponent<PlayerHPBar>();
        player = playerPrefab.GetComponent<Player>();
    }

    private void SetScoreText(int score)
    {
        //textScore.text = "Score:" + score.ToString();
    }

    private void SetHighScoreText(int highScore)
    {
        textHighScore.text = "HighScore:" + highScore.ToString();
    }

    public void AddScore(int point)
    {
        if (inGame)
        {
            score += point;
            SetScoreText(score);
        }
    }

    public bool IsInGame()
    {
        return inGame;
    }

    private void Update()
    {
        if (inGame)
        {
            leftTime -= Time.deltaTime;
            textTimer.text = "Time:" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");
            if (leftTime < 0f)
            {
                //audioSource.PlayOneShot(overSound);
                textGameOver.enabled = true;
                inGame = false;
            }

            GameObject playerObj = GameObject.Find("Player");
            GameObject[] swords = GameObject.FindGameObjectsWithTag("Sword");
            GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield");

            if (playerhp.ReturnCurrentHP() <= 0)
            {
                foreach(GameObject sword in swords)
                {
                    sword.SetActive(false);
                }
                foreach (GameObject shield in shields)
                {
                    shield.SetActive(false);
                }
                player.Lose();
                playerObj = null;
            }
            if (playerObj == null)
            {
                if (playerhp.ReturnCurrentHP() > 0)
                {
                    //audioSource.PlayOneShot(killSound);
                    GameObject newPlayer = Instantiate(playerPrefab);
                    newPlayer.name = playerPrefab.name;
                }
                else
                {
                    //audioSource.PlayOneShot(overSound);
                    textGameOver.enabled = true;
                    inGame = false;
                }
            }
            GameObject targetObj = GameObject.FindWithTag("Enemy");
            if (GameObject.FindWithTag("End") == null)
            {
                targetObj = null;
            }
            if (targetObj == null)
            {
                foreach (GameObject sword in swords)
                {
                    sword.SetActive(false);
                }
                foreach (GameObject shield in shields)
                {
                    shield.SetActive(false);
                }
                player.Win();
                //audioSource.PlayOneShot(clearSound);
                textClear.enabled = true;
                if (i != lastscene)
                {
                    nextSceneButton.SetActive(true);
                }

                int scorePoint = score * 50;
                float scoreHP = (float)playerhp.currentHP / (float)playerhp.maxHP * 1000;
                int scoreTime = (int)(leftTime * 100f);
                //textResultScore.text = "Score * 50 = " + scorePoint.ToString();
                textResultHP.text = "HP × 1000 = " + scoreHP.ToString();
                textResultTime.text = "Time × 100 = " + scoreTime.ToString();

                int totalScore = scorePoint + (int)scoreHP + scoreTime;
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

    public void ReternToStart()
    {
        SceneManager.LoadScene("opening");
    }

    public void NextScene()
    {
        i++;
        SceneManager.LoadScene(i);
    }
}
