using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    public int Hp { get { return hp; } }
    public float Speed { get { return speed; } }
    public void AttackCharacter()
    {
        // 플레이어 불릿을 생성   
    }

    public void TakeDamage()
    {
        GameManager.Instance.HitPlayer();
        hp -= 1;
    }

   public void TakePotion()
    {
        GameManager.Instance.TakePotion();
        hp += 1;
    }

}
