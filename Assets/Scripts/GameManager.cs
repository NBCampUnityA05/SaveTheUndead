using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public GameObject stageUI;
    public GameObject resultUI;

    int level;
    public int score = 0;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;

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
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    //배경음 중단 메소드도 필요함.

    /// <summary>
    /// 게임 시작. 실질적으로 게임의 흐름 전체를 담당한다.
    /// </summary>
    public void StartGame()
    {
        //배경음 재생 시작
        AudioManager.instance.PlayBgm(AudioManager.Bgm.MainScene);

        bool isAlive = true;
        int score = 0;
        //플레이어가 살아있는 동안 진행.
        //while (isAlive)
        //{
        //    //시간의 흐름에 따른 스코어 증가

        //    //이동, 공격 등의 입력 감지와 이에 대한 처리

        //    //
        //    // 

        //    /*
        //    //플레이어 피격 감지 시
        //    if ()
        //    {
        //        isAlive = HitPlayer();
        //    }
        //    */
        //}

        GameOver(score);
    }
    
    /// <summary>
    /// 플레이어가 쏜 탄환과 적의 충돌 감지 시 호출. 해당 적 제거, score +1
    /// </summary>
    public void HitEnemy()
    {
        //해당 적 제거

        score += 1;
    }

    /// <summary>
    /// 방향키 입력 감지 시 호출. 해당 키에 배정된 플레이어를 이동시키고 이동 애니메이션 출력 트리거 활성화. Player 담당자가 구현한 기능을 사용할 예정.
    /// </summary>
    public void MovePlayer()
    {

    }

    /// <summary>
    /// 플레이어와 적 또는 플레이어와 아이템의 충돌 감지 시 호출. 플레이어 체력 감소, 체력이 남아 있다면 피격 애니메이션 출력 트리거 활성화, true 반환. 아니라면 false 호출.
    /// </summary>
    public bool HitPlayer()
    {
        return false;
    }

    /// <summary>
    /// 플레이어와 아이템의 충돌 감지 시 호출. 해당 아이템 제거, 플레이어에게 효과 적용
    /// </summary>
    public void TakeItem()
    {
        
    }

    /// <summary>
    /// 사망 애니메이션 출력 트리거 활성화. 약간의 딜레이(사망 애니메이션 출력이 끝날 때 쯤) 를 주고 결과창 출력되도록. 재시도 여부 결정 가능.
    /// </summary>
    private void GameOver(int score)
    {
        //배경음 재생 중단

        //사망 애니메이션 출력 트리거 활성화

        //애니메이션 끝나갈 때 쯤까지 약간의 딜레이

        //결과창 + 재시도 버튼 출력

        /*
        //재시도 입력 감지 시
        if ()
        {
            StartGame();
        }
        */
    }
}
