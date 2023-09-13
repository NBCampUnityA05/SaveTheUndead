using UnityEngine;

public enum PlayerType
{
    ZombiePlayer1,
    ZombiePlayer2,
    SkelletionPlayer1,
    SkelletionPlayer2,
    MonsterPlayer,

}
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private GameObject[] playerPrefabs = new GameObject[5];

    public Player player{  get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        CreatePlayer((PlayerType.SkelletionPlayer1));
    }
    public Player CreatePlayer(PlayerType type)
    {
        GameObject go = Instantiate(playerPrefabs[(int)type]);
        player = go.GetComponent<Player>();
        return player;
    }
}
