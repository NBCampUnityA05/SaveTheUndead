using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWalk : MonoBehaviour
{
    public float speed = 5.0f; // 이동 속도

    void Update()
    {
        // 오른쪽 방향으로 이동
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
