using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;
    [SerializeField] private GameObject lifePrefabs;

    private void Awake()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateLife(Vector3 lifePos)
    {
        GameObject life = Instantiate(lifePrefabs, lifePos, Quaternion.Euler(0,0,0));
        return life;
    }
}
