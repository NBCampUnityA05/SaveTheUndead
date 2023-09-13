using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public GameObject stageUI;
    public Text scoreUI;
    public Text lifeUI;
    public Text highScoreUI;
    public Text currentScoreUI;
    public GameObject resultUI;
    private float score = 0f;
    private int maxLife;
    private bool isGameOver = false;

    private GameObject[] lifeList;
    private Player player;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", -1);
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager != null && selectedCharacterIndex != -1)
        {
            PlayerType selectedPlayerType = (PlayerType)selectedCharacterIndex;
            player = playerManager.CreatePlayer(selectedPlayerType);

            maxLife = player.Hp;
            lifeList = new GameObject[maxLife];
        }

        InvokeRepeating("SpawnEnemy", 1f, 1f);

        StartGame();
    }

    void Update()
    {
        if (player.Hp > 0)
        {
            PlayingGame();
        }
        else if(!isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        score = 0f;
        GetLifeList(maxLife);
        PrintLife(player.Hp);
        scoreUI.text = ((int)score).ToString();
        isGameOver = false;

        AudioManager.instance.PlayBgm(false);
        Debug.Log("BGM ReStart!!!");
        AudioManager.instance.PlayBgm(true);

        for (int i = 0; i < 36; i++)
        {
            SpawnEnemy();
        }
    }

    private void PlayingGame()
    {
        score += 0.1f;
        scoreUI.text = ((int)score).ToString();
    }

    private void SpawnEnemy()
    {
        EnemyManager.Instance.SpawnEnemy();
    }

    public void HitPlayer()
    {
        PrintLife(player.Hp);
    }

    public void TakePotion()
    {
        PrintLife(player.Hp);
    }

    private void PrintLife(int life)
    {
        for (int i = 0; i < lifeList.Length; i++)
        {
            if (i <= life - 1)
            {
                lifeList[i].SetActive(true);
            }
            else
            {
                lifeList[i].SetActive(false);
            }
        }
    }

    private void GetLifeList(int maxLife)
    {
        Vector3 lifePosition = new Vector3(-12f, 8.7f, 0f);

        for (int i = 0; i < maxLife; i++)
        {
            lifePosition.x += 1.5f;
            lifeList[i] = LifeManager.instance.CreateLife(lifePosition);
        }
    }

    private void GameOver()
    {

        
        AudioManager.instance.PlayBgm(false);
        Time.timeScale = 0f;
        resultUI.SetActive(true);

        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", (int)score);
        }
        else if(PlayerPrefs.GetInt("highScore") < (int)score)
        {
            PlayerPrefs.DeleteKey("highScore");
            PlayerPrefs.SetInt("highScore", (int)score);
        }

        highScoreUI.text = PlayerPrefs.GetInt("highScore").ToString();
        currentScoreUI.text = ((int)score).ToString();
    }
}
