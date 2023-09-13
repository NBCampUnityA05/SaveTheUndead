using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform player; 
    public Level monster; // 계속 움직이는 몬스터
    public Level monster2; // 멈췄다 움직였다 하는 몬스터

    private bool isMonster2Moving = true; // 2번 몬스터가 움직이는 중인지 여부 확인
    public float moveDuration = 2.0f; // 몬스터가 움직이는 시간
    public float stopDuration = 2.0f; // 몬스터가 멈추는 시간

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ManageMonster2Movement());
    }

    // Coroutine to manage the movement of monster2
    private IEnumerator ManageMonster2Movement()
    {
        while (true)
        {
            if (isMonster2Moving)
            {
                // 2번 몬스터가 플레이어 쪽으로 이동
                monster2.target = player;
            }
            else
            {
                // 2번 몬스터가 멈추고 자리에 머무름
                monster2.target = null;
            }

            // 움직이는 동안 기다린 후 멈추는 동안 기다림
            yield return new WaitForSeconds(isMonster2Moving ? moveDuration : stopDuration);

            // 상태를 반전 (움직이고 멈추는 상태를 번갈아가며 반복)
            isMonster2Moving = !isMonster2Moving;
        }
    }
}
