using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] Animator anim;
    public int Hp { get { return hp; } }
    public float Speed { get { return speed; } }

    public bool IsAttack { get; private set; }

    float attack_cool_time = 0f;

    private void Start()
    {
        IsAttack = false;
    }
    private void Update()
    {
        attack_cool_time-= Time.deltaTime;
    }
    public void AttackCharacter()
    {
        if (attack_cool_time > 0f) return;
        IsAttack = true;
        Invoke("CompleteAttack", 0.5f);
        attack_cool_time = 2f;
    }

    public void TakeDamage()
    {
        GameManager.Instance.HitPlayer();
        anim.SetTrigger("Hit");
        hp -= 1;
    }

   public void TakePotion()
    {
        GameManager.Instance.TakePotion();
        hp += 1;
    }

    public void CompleteAttack()
    {
        IsAttack=false;
    }

}
