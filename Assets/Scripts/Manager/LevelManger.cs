using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform player; 
    public Level monster;
    public Level monster2;

    private bool isMonster2Moving = true;
    public float moveDuration = 2.0f;
    public float stopDuration = 2.0f;
    
    void Start()
    {
        StartCoroutine(ManageMonster2Movement());
    }
    
    private IEnumerator ManageMonster2Movement()
    {
        while (true)
        {
            if (isMonster2Moving)
            {
                monster2.target = player;
            }
            else
            {
                monster2.target = null;
            }

            yield return new WaitForSeconds(isMonster2Moving ? moveDuration : stopDuration);

            isMonster2Moving = !isMonster2Moving;
        }
    }
}
