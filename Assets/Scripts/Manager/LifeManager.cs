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

    public GameObject CreateLife(Vector3 lifePos)
    {
        GameObject life = Instantiate(lifePrefabs, lifePos, Quaternion.Euler(0,0,0));
        return life;
    }
}
