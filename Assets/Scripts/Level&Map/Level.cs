using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2.0f;
    public float speedIncreaseInterval = 1.0f;
    public float speedIncreaseAmount = 10.0f;

    private float nextSpeedIncreaseTime;

    void Start()
    {
        nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
    }

    void Update()
    {
        Debug.Log("몬스터 이동 속도: " + moveSpeed);
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (Time.time >= nextSpeedIncreaseTime)
            {
                moveSpeed += speedIncreaseAmount;
                nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
            }
        }
    }
}
