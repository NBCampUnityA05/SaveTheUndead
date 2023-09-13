using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    [SerializeField] private GameObject lifePrefab;

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
        
    }

    public GameObject createLife(Vector3 lifePosition)
    {
        GameObject life = Instantiate(lifePrefab, lifePosition, Quaternion.Euler(0,0,0));
        return life;
    }
}
