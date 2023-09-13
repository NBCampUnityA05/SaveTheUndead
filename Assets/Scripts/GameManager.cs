using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public GameObject stageUI;
    public Text scoreUI;
    public Text lifeText;
    public Text highScoreUI;
    public Text currentScoreUI;
    public GameObject resultUI;
    private float score = 0f;
    private int maxLife = 0;
    private int life = 0;
    private bool isGameOver = false;
    int level;

    private GameObject[] lifeList;//Life 스프라이트의 배열. 가장 뒤에서부터 비활성화시키는 식으로 표현할 것임.

    private Player player;

    //점수는 (생존 시간 + 제거한 적 수) 정도면 될듯? 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 불러오는 함수
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", -1);
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager != null && selectedCharacterIndex != -1)
        {
            PlayerType selectedPlayerType = (PlayerType)selectedCharacterIndex;
            player = playerManager.CreatePlayer(selectedPlayerType);

            maxLife = player.Hp;
            life = maxLife;

            lifeList = new GameObject[maxLife];
        }

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어가 살아있다면
        if (life > 0)
        {
            PlayingGame();
        }
        //플레이어 사망, 게임 종료 메소드가 실행된 적 없다면
        else if(!isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
    }

    //캐릭터 선택 => 메인씬 호출하는 기능은 있음.
    //선택한 캐릭터 정보가 메인 씬으로 넘어오도록 해야 함.
    //이 부분은 잠깐 보류.

    //옵션에서 설정한 정보 또한 메인 씬으로 넘어와야 함.
    //이 부분은 AudioManager 를 DontDestroyOnLoad 처리해두는 것으로 해결했다고 함.
    //StartSecene 에 있는 AudioManager 를 사용할 수 있음.


    //선택된 캐릭터에 따라 차별화된 능력치 부여 + 해당 스프라이트가 적용되도록 해야 함(이건 사실상 전적으로 내가 해야 함.)

    //플레이어의 상황에 맞도록 평상시, 사망 시, 피격 시, 이동 시 애니메이션 적용.
    //(방향키 입력이 전혀 없는 상태일 때는 평상시 애니메이션이 디폴트, 방향키 입력되는 동안 이동 애니메이션 적용)
    //(어떤 애니메이션이 재생 중이건 피격 시에는 피격 애니메이션이 우선적으로 적용된다. 체력이 0이 됐다면 사망 애니메이션 출력, 약간의 딜레이 후 결과창 출력)

    //아이템 획득 시, 해당 아이템 투사체를 제거하고 아이템 효과가 플레이어에게 적용되도록 해야 함(EnemyManager 담당자가 구현한 기능 사용)

    //StartScene 에서 설정한 옵션 값이 MainScene 에서도 적용되도록 해야 함.(Audio 부분 한정이라면, DontDestroyOnLoad 처리 된 AudioManager 호출하면 됨)

    //일정 시간 경과 시 난이도 증가 기능(LevelManager 담당자가 구현한 기능 사용)
    //(맵 반경 축소 or 적(투사체) 이동 속도 증가)

    //플레이어가 적과 충돌 시 목숨 감소(PlayerManager, EnemyManager 담당자가 구현한 기능 사용)

    //플레이어가 쏜 총알이 적과 충돌 시 적 제거, 점수 증가(PlayerManager 담당자가 구현한 기능 사용)

    //플레이어 사망 시 결과창 출력(UIManager 담당자가 구현한 기능 사용)

    //플레이어에게 날아오는 오브젝트는 '적' 뿐만 아니라 아이템도 섞여 있음. 일단은 둘 다 '적' 취급이므로 플레이어의 공격에 닿으면 소멸한다.
    //아이템은 별도의 태그를 달아서 이것을 통해 구분하도록 한다.

    //배경음 중단 메소드도 필요함.

    /// <summary>
    /// 게임 시작. 게임을 시작할 때 각 요소를 세팅한다.
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1f;
        score = 0f;
        life = maxLife;
        scoreUI.text = ((int)score).ToString();
        Debug.Log($"MAX_LIFE : {maxLife}");
        GetLifeList(maxLife);
        PrintLife(life);
        isGameOver = false;

        AudioManager.instance.PlayBgm(false);
        Debug.Log("BGM ReStart!!!");
        AudioManager.instance.PlayBgm(true);
    }

    /// <summary>
    /// 게임 시작. 실질적으로 게임의 흐름 전체를 담당한다.
    /// </summary>
    private void PlayingGame()
    {
        score += 0.1f;
        scoreUI.text = ((int)score).ToString();
    }

    /// <summary>
    /// 플레이어가 쏜 탄환과 적 or 아이템 충돌 감지 시 호출. 플레이어의 탄환과 해당 투사체 제거. 아이템을 맞췄어도 얄짤없다.
    /// </summary>
    public void HitProjectile()
    {
        //해당 투사체 제거
        //플레이어에게 날아오는 오브젝트는 '적' 뿐만 아니라 아이템도 섞여 있음. 일단은 둘 다 '적' 취급이므로 플레이어의 공격에 닿으면 소멸한다.
        score += 10f;
    }

    /// <summary>
    /// 플레이어와 적 충돌 감지 시 호출. 플레이어 체력 감소.
    /// </summary>
    public void HitPlayer()
    {
        //적과 충돌했다면 플레이어 체력 감소, 체력이 남아 있다면 피격 애니메이션 출력 트리거 활성화
        //아이템과 충돌했다면 플레이어에게 해당 아이템 효과 적용
        life -= 1;
        if (life <= 0) 
        { 
            life = 0;
        }

        PrintLife(life);
    }

    /// <summary>
    /// 플레이어와 포션 아이템의 충돌 감지 시 호출. 체력이 깎인 상태라면 체력 회복 적용
    /// </summary>
    public void TakePotion()
    {
        if (life < maxLife)
        {
            life += 1;
        }

        PrintLife(life);
    }

    /// <summary>
    /// 각 체력 스프라이트를 활성, 비활성화 시켜서 현재 체력 수치를 표현한다.
    /// </summary>
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

    /// <summary>
    /// 체력 스프라이트 가져오기
    /// </summary>
    private void GetLifeList(int maxLife)
    {
        Vector3 lifePosition = new Vector3(-12.5f, 8.7f, 0f);

        for (int i = 0; i < maxLife; i++)
        {
            lifePosition.x += 1.5f;
            
            lifeList[i] = LifeManager.instance.createLife(lifePosition);
            if (lifeList[i] != null) { Debug.Log("GetLife!"); }
        }
    }

    /// <summary>
    /// 사망 애니메이션 출력 트리거 활성화. 약간의 딜레이(사망 애니메이션 출력이 끝날 때 쯤) 를 주고 결과창 출력되도록. 재시도 여부 결정 가능.
    /// </summary>
    private void GameOver()
    {

        //배경음 재생 중단
        AudioManager.instance.PlayBgm(false);

        //사망 애니메이션 출력 트리거 활성화

        //애니메이션 끝나갈 때 쯤까지 약간의 딜레이

        //결과창 + 재시도 버튼 출력
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
