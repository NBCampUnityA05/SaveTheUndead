using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform target; // 플레이어 오브젝트의 Transform을 할당해주세요.
    public float moveSpeed = 2.0f;
    public float speedIncreaseInterval = 1.0f; //  이동속도 증가를 몇 초마다 주는지
    public float speedIncreaseAmount = 10.0f; // 속도 증가량

    private float nextSpeedIncreaseTime;

    // Start is called before the first frame update
    void Start()
    {
        nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("몬스터 이동 속도: " + moveSpeed);
        if (target != null)
        {
            // 몬스터를 플레이어 방향으로 이동시킵니다.
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // 일정 시간마다 속도를 증가시킵니다.
            if (Time.time >= nextSpeedIncreaseTime)
            {
                moveSpeed += speedIncreaseAmount;
                nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
            }
        }
    }
}
