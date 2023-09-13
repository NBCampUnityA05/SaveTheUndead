using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] Animator anim;
    [SerializeField] Animator atkAnim;

    public int maxHp;
    public int Hp { get { return hp; } }
    public float Speed { get { return speed; } }

    public bool IsAttack { get; private set; }

    float attack_cool_time = 0f;

    private void Start()
    {
        IsAttack = false;
        maxHp = hp;
    }
    private void Update()
    {
        attack_cool_time-= Time.deltaTime;
    }
    public void AttackCharacter()
    {
        if (attack_cool_time > 0f) return;
        IsAttack = true;

        atkAnim.SetTrigger("Attack");
        GameManager.Instance.Attack();
        Invoke("CompleteAttack", 1f);
        attack_cool_time = 3f;
    }

    public void TakeDamage()
    {
        anim.SetTrigger("Hit");
        hp -= 1;

        if (hp < 0) { hp = 0; }
        GameManager.Instance.HitPlayer();
    }

   public void TakePotion()
    {
        if(hp < maxHp)
        {
            hp += 1;
        }
        GameManager.Instance.TakePotion();
    }

    public void CompleteAttack()
    {
        IsAttack=false;
    }

}
